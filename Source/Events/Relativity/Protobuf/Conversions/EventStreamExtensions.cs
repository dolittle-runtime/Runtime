/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using Dolittle.Artifacts;
using Dolittle.Collections;
using Dolittle.Execution;
using Dolittle.Protobuf;
using Dolittle.Runtime.Events.Processing;
using Dolittle.Runtime.Events.Store;
using Dolittle.Runtime.Protobuf;
using Dolittle.Time;

namespace Dolittle.Runtime.Events.Relativity.Protobuf.Conversion
{
    /// <summary>
    /// Extensions for event streams to convert to and from protobuf representations
    /// </summary>
    public static class EventStreamExtensions
    {
        /// <summary>
        /// Convert a <see cref="Dolittle.Events.Relativity.Microservice.CommittedEventStream"/> to <see cref="CommittedEventStream"/>
        /// </summary>
        /// <param name="protobuf"><see cref="Dolittle.Events.Relativity.Microservice.CommittedEventStream"/> to convert from</param>
        /// <returns>Converted <see cref="CommittedEventStream"/></returns>
        public static CommittedEventStream ToCommittedEventStream(this Dolittle.Events.Relativity.Microservice.CommittedEventStream protobuf)
        {
            var eventSourceId = protobuf.Source.EventSource.To<EventSourceId>();
            var artifactId = protobuf.Source.Artifact.To<ArtifactId>();
            var versionedEventSource = new VersionedEventSource(eventSourceId, artifactId);
            var commitId = protobuf.Id.To<CommitId>();
            var correlationId = protobuf.CorrelationId.To<CorrelationId>();
            var timeStamp = protobuf.TimeStamp.ToDateTimeOffset();
            
            var events = protobuf.Events.Select(_ =>                 
                new EventEnvelope(
                    _.Metadata.ToEventMetadata(),
                    _.Event.ToPropertyBag()
                )
            ).ToArray();

            return new CommittedEventStream(
                protobuf.Sequence,
                versionedEventSource,
                commitId,
                correlationId,
                timeStamp,
                new EventStream(events)
            );
        }

        /// <summary>
        /// Convert from <see cref="CommittedEventStream"/> to <see cref="Dolittle.Events.Relativity.Microservice.CommittedEventStream"/>
        /// </summary>
        /// <param name="committedEventStream"><see cref="CommittedEventStream"/> to convert from</param>
        /// <returns>The converted <see cref="Dolittle.Events.Relativity.Microservice.CommittedEventStream"/></returns>
        public static Dolittle.Events.Relativity.Microservice.CommittedEventStream ToProtobuf(this CommittedEventStream committedEventStream)
        {
            var protobuf = new Dolittle.Events.Relativity.Microservice.CommittedEventStream
            {
                Sequence = committedEventStream.Sequence,
                Source = committedEventStream.Source.ToProtobuf(),
                Id = committedEventStream.Id.ToProtobuf(),
                CorrelationId = committedEventStream.CorrelationId.ToProtobuf(),
                TimeStamp = committedEventStream.Timestamp.ToUnixTimeMilliseconds()
            };

            committedEventStream.Events.Select(@event =>
            {
                var envelope = new Dolittle.Events.Relativity.Microservice.EventEnvelope
                {
                    Metadata = @event.Metadata.ToProtobuf()
                };
                envelope.Event = @event.Event.ToProtobuf();

                return envelope;
            }).ForEach(protobuf.Events.Add);

            return protobuf;
        }

        /// <summary>
        /// Convert from <see cref="CommittedEventStreamWithContext"/> to <see cref="Dolittle.Events.Relativity.Microservice.CommittedEventStream"/>
        /// </summary>
        /// <param name="contextualEventStream"><see cref="CommittedEventStreamWithContext"/> to convert from</param>
        /// <returns>Converted <see cref="Dolittle.Events.Relativity.Microservice.CommittedEventStream"/></returns>
        public static Dolittle.Events.Relativity.Microservice.CommittedEventStreamWithContext ToProtobuf(this CommittedEventStreamWithContext contextualEventStream)
        {
            var protobuf = new Dolittle.Events.Relativity.Microservice.CommittedEventStreamWithContext
            {
                Commit = contextualEventStream.EventStream.ToProtobuf(),
                Context = contextualEventStream.Context.ToProtobuf()
            };

            return protobuf;
        }

        /// <summary>
        /// Convert from <see cref="Dolittle.Events.Relativity.Microservice.CommittedEventStreamWithContext"/> to <see cref="CommittedEventStreamWithContext"/>
        /// </summary>
        /// <param name="protobuf"><see cref="Dolittle.Events.Relativity.Microservice.CommittedEventStreamWithContext"/> to convert from</param>
        /// <returns>Converted <see cref="CommittedEventStreamWithContext"/></returns>
        public static CommittedEventStreamWithContext ToCommittedEventStreamWithContext(this Dolittle.Events.Relativity.Microservice.CommittedEventStreamWithContext protobuf)
        {
            var context = protobuf.Context.ToExecutionContext();
            var committedEventStream = protobuf.Commit.ToCommittedEventStream();

            return new CommittedEventStreamWithContext(committedEventStream, context);
        }
    }
}