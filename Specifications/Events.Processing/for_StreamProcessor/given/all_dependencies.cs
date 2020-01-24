// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Machine.Specifications;

namespace Dolittle.Runtime.Events.Processing.for_StreamProcessor.given
{
    public class all_dependencies
    {
        protected static StreamId source_stream_id;
        protected static IStreamProcessorStateRepository stream_processor_state_repository;
        protected static IFetchNextEvent next_event_fetcher;
        Establish context = () =>
        {
            var in_memory_stream_processor_state_repository = new in_memory_stream_processor_state_repository();

            source_stream_id = Guid.NewGuid();
            stream_processor_state_repository = in_memory_stream_processor_state_repository;
            next_event_fetcher = Processing.given.a_next_event_fetcher_mock().Object;
        };
    }
}