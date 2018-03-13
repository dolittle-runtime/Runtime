﻿using System;
using Machine.Specifications;

namespace Dolittle.Queries.Validation.Specs.for_QueryValidationDescriptors.given
{
    public class no_query_validation_descriptors : given.all_dependencies
    {
        protected static QueryValidationDescriptors descriptors;

        Establish context = () =>
        {
            type_finder.Setup(t => t.FindMultiple(typeof(QueryValidationDescriptorFor<>))).Returns(new Type[0]);
            descriptors = new QueryValidationDescriptors(type_finder.Object, container.Object);
        };
    }
}
