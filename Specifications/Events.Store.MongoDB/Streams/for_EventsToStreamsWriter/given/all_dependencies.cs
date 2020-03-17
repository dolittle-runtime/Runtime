// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Dolittle.Logging;
using Dolittle.Types.Testing;
using Machine.Specifications;
using Moq;

namespace Dolittle.Runtime.Events.Store.MongoDB.Streams.for_EventsToStreamsWriter.given
{
    public class all_dependencies
    {
        protected static an_event_store_connection an_event_store_connection;
        protected static Mock<PublicEventsWriter> public_events_writer;
        protected static EventsToStreamsWriter events_to_streams_writer;

        Establish context = () =>
        {
            an_event_store_connection = new an_event_store_connection(new a_mongo_db_connection());
            public_events_writer = new Mock<PublicEventsWriter>(an_event_store_connection, Mock.Of<ILogger>());

            events_to_streams_writer = new EventsToStreamsWriter(
                new StaticInstancesOf<ICanWriteEventsToWellKnownStreams>(public_events_writer.Object),
                an_event_store_connection,
                Mock.Of<ILogger>());
        };

        Cleanup cleanup = () => an_event_store_connection.Dispose();
    }
}