// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Dolittle.Runtime.Services;
using Dolittle.Services;

namespace Dolittle.Runtime.Events.Processing.Filters.EventHorizon
{
    /// <summary>
    /// Represents an implementation of <see cref="ICanBindRuntimeServices"/> for exposing
    /// runtime service implementations for Heads.
    /// </summary>
    public class RuntimeServices : ICanBindRuntimeServices
    {
        readonly PublicFiltersService _publicFilters;

        /// <summary>
        /// Initializes a new instance of the <see cref="RuntimeServices"/> class.
        /// </summary>
        /// <param name="publicFilters">The <see cref="PublicFiltersService" />.</param>
        public RuntimeServices(PublicFiltersService publicFilters)
        {
            _publicFilters = publicFilters;
        }

        /// <inheritdoc/>
        public ServiceAspect Aspect => "EventHorizon";

        /// <inheritdoc/>
        public IEnumerable<Service> BindServices() =>
            new Service[]
            {
                new Service(_publicFilters, Contracts.PublicFilters.BindService(_publicFilters), Contracts.PublicFilters.Descriptor)
            };
    }
}