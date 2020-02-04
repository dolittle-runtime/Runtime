// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using Dolittle.Logging;
using Dolittle.Runtime.Events.Processing;
using Grpc.Core;
using static Dolittle.Runtime.Events.Processing.Filters;

namespace Dolittle.Runtime.Events.Runtime
{
    /// <summary>
    /// Represents the implementation of.
    /// </summary>
    public class FiltersService : FiltersBase
    {
        readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="FiltersService"/> class.
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> for logging.</param>
        public FiltersService(ILogger logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public override async Task Connect(IAsyncStreamReader<FilterClientToRuntimeResponse> requestStream, IServerStreamWriter<FilterRuntimeToClientRequest> responseStream, ServerCallContext context)
        {
            await Task.Run(async () =>
            {
                while (await requestStream.MoveNext(context.CancellationToken).ConfigureAwait(false))
                {
                    _logger.Information($"Message received");
                }
            }).ConfigureAwait(false);

            while (!context.CancellationToken.IsCancellationRequested)
            {
            }
        }
   }
}