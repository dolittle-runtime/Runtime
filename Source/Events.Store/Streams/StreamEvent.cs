// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Dolittle.Concepts;

namespace Dolittle.Runtime.Events.Store.Streams
{
    /// <summary>
    /// Represents a <see cref="CommittedEvent" /> that is a part of a stream.
    /// </summary>
    public class StreamEvent : Value<StreamEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StreamEvent"/> class.
        /// </summary>
        /// <param name="event">The <see cref="CommittedEvent" />.</param>
        /// <param name="position">The <see cref="StreamPosition" />.</param>
        /// <param name="stream">The <see cref="StreamId" />.</param>
        /// <param name="partition">The <see cref="PartitionId" />.</param>
        /// <param name="partitioned">Whether the event is partitioned.</param>
        public StreamEvent(CommittedEvent @event, StreamPosition position, StreamId stream, PartitionId partition, bool partitioned)
        {
            Event = @event;
            Position = position;
            Stream = stream;
            Partition = partition;
            Partitioned = partitioned;
        }

        /// <summary>
        /// Gets the <see cref="StreamPosition" /> of the event in its stream.
        /// </summary>
        public StreamPosition Position { get; }

        /// <summary>
        /// Gets the <see cref="CommittedEvent" />.
        /// </summary>
        public CommittedEvent Event { get; }

        /// <summary>
        /// Gets the <see cref="StreamId" /> stream that this event is a part of.
        /// </summary>
        public StreamId Stream { get; }

        /// <summary>
        /// Gets the <see cref="PartitionId">partition </see> that this event belongs to.
        /// </summary>
        public PartitionId Partition { get; }

        /// <summary>
        /// Gets a value indicating whether the StreamEvent is partitioned.
        /// </summary>
        public bool Partitioned { get; }
    }
}
