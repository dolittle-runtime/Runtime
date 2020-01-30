// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Dolittle.Logging;
using Machine.Specifications;

namespace Dolittle.Runtime.Events.Processing.for_RemoteFilterProcessor.when_filtering
{
    public class and_filtering_failed : given.all_dependencies
    {
        static RemoteFilterProcessor remote_processor;
        static IProcessingResult result;

        Establish context = () => remote_processor = new RemoteFilterProcessor(event_processor_id, target_stream_id, Processing.given.a_remote_filter_service(new FailedFilteringResult()), event_to_stream_writer_mock.Object, Moq.Mock.Of<ILogger>());

        Because of = async () => result = await remote_processor.Process(an_event);

        It should_not_succeed_processing = () => result.Succeeded.ShouldEqual(false);
        It should_not_retry_processing = () => result.Retry.ShouldEqual(false);
        It should_write_the_event_to_stream = () => event_to_stream_writer_mock.Verify(_ => _.Write(Moq.It.IsAny<CommittedEvent>(), Moq.It.IsAny<StreamId>()), Moq.Times.Never());
    }
}