// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Dolittle.Logging;
using Dolittle.Runtime.Events.Streams;
using Machine.Specifications;
using MongoDB.Driver;

namespace Dolittle.Runtime.Events.Store.MongoDB.Processing.for_EventsToStreamsWriter
{
    public class when_writing_an_event_to_stream : given.all_dependencies
    {
        static EventsToStreamsWriter events_to_streams_writer;
        static CommittedEvent committed_event;
        static StreamId stream_id;
        static PartitionId partition;
        static IMongoCollection<MongoDB.Events.StreamEvent> stream;

        Establish context = () =>
        {
            committed_event = committed_events.a_committed_event(0);
            events_to_streams_writer = new EventsToStreamsWriter(an_event_store_connection, Moq.Mock.Of<ILogger>());
            stream_id = Guid.NewGuid();
            partition = Guid.NewGuid();
            stream = an_event_store_connection.GetStreamCollectionAsync(stream_id).GetAwaiter().GetResult();
        };

        Because of = () => events_to_streams_writer.Write(committed_event, stream_id, partition).GetAwaiter().GetResult();

        It should_have_written_one_event_to_stream = () => stream.Find(filters.a_stream_event_filter.Empty).ToList().Count.ShouldEqual(1);

        It should_have_stored_one_event_at_position_zero = () => stream.Find(filters.a_stream_event_filter.Eq(_ => _.StreamPosition, 0U)).SingleOrDefault().ShouldNotBeNull();

        It should_have_stored_the_event_with_exactly_the_same_data_as_committed_event = () => committed_event.ShouldBeStoredWithCorrectStoreRepresentation(stream.Find(filters.a_stream_event_filter.Empty).First(), 0, partition);
    }
}