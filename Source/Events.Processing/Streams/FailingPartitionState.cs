// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Dolittle.Concepts;
using Dolittle.Runtime.Events.Store.Streams;

namespace Dolittle.Runtime.Events.Processing.Streams
{
    /// <summary>
    /// Represents the state of a failing partition.
    /// </summary>
    public class FailingPartitionState : Value<FailingPartitionState>
    {
        /// <summary>
        /// Gets or sets the <see cref="StreamPosition" /> of the next event to process.
        /// </summary>
        public StreamPosition Position { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DateTimeOffset" /> for when to retry processing.
        /// </summary>
        public DateTimeOffset RetryTime { get; set; }

        /// <summary>
        /// Gets or sets the reason for failure.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets the number of times that the event at position has been attempted processed.
        /// </summary>
        public uint ProcessingAttempts { get; set; }
    }
}