﻿using Machine.Specifications;

namespace Dolittle.Queries.Validation.Specs.for_QueryValidator.given
{
    public class a_query_validator : all_dependencies
    {
        protected static QueryValidator query_validator;

        Establish context = () => query_validator = new QueryValidator(query_validation_descriptors_mock.Object, rule_contexts_mock.Object);
    }
}
