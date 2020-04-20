// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Dolittle.Runtime.Events.Store.Streams;
using Machine.Specifications;

namespace Dolittle.Runtime.Events.Store.MongoDB.Streams.for_EventFromEventLogFetcher.when_fetching_a_range_of_events
{
    public class and_range_to_position_is_less_than_from_position : given.all_dependencies
    {
        static Exception exception;

        Because of = () => exception = Catch.Exception(() => fetcher.FetchRange(StreamId.AllStreamId, new StreamPositionRange(1, 0)).GetAwaiter().GetResult());

        It should_fail_because_from_position_is_greater_than_to_position_in_range = () => exception.ShouldBeOfExactType<FromPositionIsGreaterThanToPosition>();
    }
}