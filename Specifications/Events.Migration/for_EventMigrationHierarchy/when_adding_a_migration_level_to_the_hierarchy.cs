﻿// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Dolittle.Runtime.Events.Migration.Specs.Fakes.v2;
using Machine.Specifications;

namespace Dolittle.Runtime.Events.Migration.Specs.for_EventMigrationHierarchy
{
    public class when_adding_a_migration_level_to_the_hierarchy : given.an_initialized_event_migration_hierarchy
    {
        Because of = () => event_migration_hierarchy.AddMigrationLevel(typeof(SimpleEvent));

        It should_have_still_have_the_logical_event_set_correctly = () => event_migration_hierarchy.LogicalEvent.ShouldEqual(hierarchy_for_type);
        It should_have_a_migration_level_of_one = () => event_migration_hierarchy.MigrationLevel.ShouldEqual(1);
    }
}