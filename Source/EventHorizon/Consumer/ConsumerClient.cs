// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
extern alias contracts;

using System;
using System.Threading;
using System.Threading.Tasks;
using Dolittle.DependencyInversion;
using Dolittle.Execution;
using Dolittle.Lifecycle;
using Dolittle.Logging;
using Dolittle.Protobuf;
using Dolittle.Runtime.Events.Processing.Streams;
using Dolittle.Runtime.Events.Store;
using Dolittle.Runtime.Events.Streams;
using Dolittle.Runtime.Microservices;
using Dolittle.Services.Clients;
using grpc = contracts::Dolittle.Runtime.EventHorizon;

namespace Dolittle.Runtime.EventHorizon.Consumer
{
    /// <summary>
    /// Represents an implementation of <see cref="IConsumerClient" />.
    /// </summary>
    [Singleton]
    public class ConsumerClient : IConsumerClient
    {
        readonly IClientManager _clientManager;
        readonly IExecutionContextManager _executionContextManager;
        readonly FactoryFor<IStreamProcessors> _getStreamProcessors;
        readonly FactoryFor<IStreamProcessorStateRepository> _getStreamProcessorStates;
        readonly FactoryFor<IWriteEventHorizonEvents> _getReceivedEventsWriter;
        readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumerClient"/> class.
        /// </summary>
        /// <param name="clientManager">The <see cref="IClientManager" />.</param>
        /// <param name="executionContextManager">The <see cref="IExecutionContextManager" />.</param>
        /// <param name="getStreamProcessors">The <see cref="FactoryFor{IStreamProcessors}" />.</param>
        /// <param name="getStreamProcessorStates">The <see cref="FactoryFor{IStreamProcessorStateRepository}" />.</param>
        /// <param name="getReceivedEventsWriter">The <see cref="FactoryFor{IWriteReceivedEvents}" />.</param>
        /// <param name="logger">The <see cref="ILogger" />.</param>
        public ConsumerClient(
            IClientManager clientManager,
            IExecutionContextManager executionContextManager,
            FactoryFor<IStreamProcessors> getStreamProcessors,
            FactoryFor<IStreamProcessorStateRepository> getStreamProcessorStates,
            FactoryFor<IWriteEventHorizonEvents> getReceivedEventsWriter,
            ILogger logger)
        {
            _clientManager = clientManager;
            _executionContextManager = executionContextManager;
            _getStreamProcessors = getStreamProcessors;
            _getStreamProcessorStates = getStreamProcessorStates;
            _getReceivedEventsWriter = getReceivedEventsWriter;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task SubscribeTo(EventHorizon eventHorizon, ScopeId scope, StreamId publicStream, PartitionId partition, MicroserviceAddress microserviceAddress)
        {
            while (true)
            {
                var cancellationTokenSource = new CancellationTokenSource();
                cancellationTokenSource.Token.ThrowIfCancellationRequested();
                var streamProcessorId = new StreamProcessorId(scope, eventHorizon.ProducerTenant.Value, eventHorizon.ProducerMicroservice.Value);
                _logger.Debug($"Tenant '{eventHorizon.ConsumerTenant}' is subscribing to events from tenant '{eventHorizon.ProducerTenant} in microservice '{eventHorizon.ProducerMicroservice}' on '{microserviceAddress.Host}:{microserviceAddress.Port}' in scope {scope}");
                try
                {
                    var publicEventsPosition = (await _getStreamProcessorStates().GetOrAddNew(streamProcessorId).ConfigureAwait(false)).Position;
                    var call = _clientManager
                        .Get<grpc.Consumer.ConsumerClient>(microserviceAddress.Host, microserviceAddress.Port)
                        .Subscribe(
                            new grpc.ConsumerSubscription
                            {
                                Tenant = eventHorizon.ProducerTenant.ToProtobuf(),
                                LastReceived = (int)publicEventsPosition.Value - 1,
                                Stream = publicStream.ToProtobuf(),
                                Partition = partition.ToProtobuf()
                            }, cancellationToken: cancellationTokenSource.Token);
                    var eventsFetcher = new EventsFromEventHorizonFetcher(
                        eventHorizon,
                        call,
                        _logger);
                    _getStreamProcessors().Register(
                        new EventHorizonEventProcessor(scope, eventHorizon, _getReceivedEventsWriter(), _logger),
                        eventsFetcher,
                        eventHorizon.ProducerMicroservice.Value,
                        cancellationTokenSource.Token);

                    while (!cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        await Task.Delay(1000).ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, $"Error occurred while handling Event Horizon to microservice '{eventHorizon.ProducerMicroservice}' and tenant '{eventHorizon.ProducerTenant}'");
                }
                finally
                {
                    _logger.Debug($"Disconnecting Event Horizon from tenant '{eventHorizon.ConsumerTenant}' to microservice '{eventHorizon.ProducerMicroservice}' and tenant '{eventHorizon.ProducerTenant}'");
                    _executionContextManager.CurrentFor(eventHorizon.ConsumerTenant);
                    _getStreamProcessors().Unregister(scope, streamProcessorId.EventProcessorId, streamProcessorId.SourceStreamId);
                    cancellationTokenSource.Dispose();
                }
            }
        }
    }
}