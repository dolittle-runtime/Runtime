// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Dolittle.Runtime.Events.Store;
using Dolittle.Runtime.Events.Store.Streams;
using Machine.Specifications;

namespace Dolittle.Runtime.Events.Processing.Streams.for_FailingPartitions.when_catching_up.and_there_are_multiple_failing_partitions.given
{
    public class all_dependencies : when_catching_up.given.all_dependencies
    {
        protected static PartitionId first_failing_partition_id;
        protected static PartitionId second_failing_partition_id;
        protected static StreamPosition first_initial_failing_partition_position;
        protected static StreamPosition second_initial_failing_partition_position;
        protected static string first_initial_failing_partition_reason;
        protected static string second_initial_failing_partition_reason;
        protected static DateTimeOffset first_initial_failing_partition_retry_time;
        protected static DateTimeOffset second_initial_failing_partition_retry_time;
        protected static FailingPartitionState first_failing_partition_state;
        protected static FailingPartitionState second_failing_partition_state;

        Establish context = () =>
        {
            first_failing_partition_id = Guid.NewGuid();
            second_failing_partition_id = Guid.NewGuid();
            first_initial_failing_partition_position = second_initial_failing_partition_position = 0;
            first_initial_failing_partition_reason = second_initial_failing_partition_reason = "some reason";
            first_initial_failing_partition_retry_time = second_initial_failing_partition_retry_time = DateTimeOffset.UtcNow;
            first_failing_partition_state = new FailingPartitionState
            {
                Position = first_initial_failing_partition_position,
                Reason = first_initial_failing_partition_reason,
                RetryTime = first_initial_failing_partition_retry_time,
                ProcessingAttempts = 1
            };
            second_failing_partition_state = new FailingPartitionState
            {
                Position = second_initial_failing_partition_position,
                Reason = second_initial_failing_partition_reason,
                RetryTime = second_initial_failing_partition_retry_time,
                ProcessingAttempts = 1
            };
            stream_processor_state.FailingPartitions.Add(first_failing_partition_id, first_failing_partition_state);
            stream_processor_state.FailingPartitions.Add(second_failing_partition_id, second_failing_partition_state);

            events_fetcher
                .Setup(_ => _.FindNext(Moq.It.IsAny<ScopeId>(), Moq.It.IsAny<StreamId>(), Moq.It.IsAny<PartitionId>(), Moq.It.IsAny<StreamPosition>(), Moq.It.IsAny<CancellationToken>()))
                .Returns<ScopeId, StreamId, PartitionId, StreamPosition, CancellationToken>((scope, stream, partition, position, _) =>
                {
                    if (partition == first_failing_partition_id) position = position.Value % 2 != 0 ? position.Increment() : position;
                    else position = position.Value % 2 == 0 ? position.Increment() : position;
                    if (position.Value >= initial_stream_processor_position) return Task.FromResult(new StreamPosition(uint.MaxValue));
                    return Task.FromResult(position);
                });
        };
    }
}