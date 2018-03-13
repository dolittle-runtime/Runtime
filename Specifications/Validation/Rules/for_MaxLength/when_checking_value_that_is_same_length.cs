﻿using System;
using Dolittle.Rules;
using Dolittle.Validation;
using Dolittle.Validation.Rules;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dolittle.Specs.Validation.Rules.for_MaxLength
{
    public class when_checking_value_that_is_same_length
    {
        static string value = "1234";
        static MaxLength rule;
        static Mock<IRuleContext> rule_context_mock;

        Establish context = () => 
        {
            rule = new MaxLength(null, 4);
            rule_context_mock = new Mock<IRuleContext>();
        };

        Because of = () => rule.Evaluate(rule_context_mock.Object, value);

        It should_not_fail = () => rule_context_mock.Verify(r => r.Fail(rule, value, Moq.It.IsAny<BrokenRuleReason>()), Times.Never());
    }
}
