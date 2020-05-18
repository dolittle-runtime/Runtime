// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dolittle.Runtime.Events.Store.MongoDB.Processing.Streams
{
    /// <summary>
    /// Represents the base class for <see cref="StreamProcessorState"/> and <see cref="Partitioned.PartitionedStreamProcessorState"/>.
    /// </summary>
    /// <remarks>
    /// The <see cref="StreamProcessorStateDiscriminatorConvention"/> is used to deserialise either a
    /// <see cref="StreamProcessorState"/> or a <see cref="Partitioned.PartitionedStreamProcessorState"/> from a stream
    /// processor state collection.
    /// </remarks>
    [BsonKnownTypes(typeof(StreamProcessorState), typeof(Partitioned.PartitionedStreamProcessorState))]
    [BsonIgnoreExtraElements]
    public abstract class AbstractStreamProcessorState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractStreamProcessorState"/> class.
        /// </summary>
        /// <param name="scopeId">The <see cref="ScopeId" />.</param>
        /// <param name="eventProcessorId">The <see cref="EventProcessorId" />.</param>
        /// <param name="sourceStreamId">The <see cref="SourceStreamId" />.</param>
        /// <param name="position">The position.</param>
        /// <param name="lastSuccessfullyProcessed">The timestamp of when the Stream was last processed successfully.</param>
        protected AbstractStreamProcessorState(
            Guid scopeId,
            Guid eventProcessorId,
            Guid sourceStreamId,
            ulong position,
            DateTimeOffset lastSuccessfullyProcessed)
        {
            ScopeId = scopeId;
            EventProcessorId = eventProcessorId;
            SourceStreamId = sourceStreamId;
            Position = position;
            LastSuccessfullyProcessed = lastSuccessfullyProcessed;
        }

        /// <summary>
        /// Gets or sets the scope id.
        /// </summary>
        public Guid ScopeId { get; set; }

        /// <summary>
        /// Gets or sets the event processor id.
        /// </summary>
        public Guid EventProcessorId { get; set; }

        /// <summary>
        /// Gets or sets the source stream id.
        /// </summary>
        public Guid SourceStreamId { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        [BsonRepresentation(BsonType.Decimal128)]
        public ulong Position { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the StreamProcessor has processed the stream.
        /// </summary>
        [BsonRepresentation(BsonType.Document)]
        public DateTimeOffset LastSuccessfullyProcessed { get; set; }
    }
}
