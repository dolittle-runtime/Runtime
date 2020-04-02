// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

extern alias contracts;

using System.Collections.Generic;
using Dolittle.Runtime.Services;
using Dolittle.Services;

namespace Dolittle.Runtime.Heads
{
    /// <summary>
    /// Represents an implementation of <see cref="ICanBindRuntimeServices"/> for exposing
    /// management service implementations for DependencyInversion.
    /// </summary>
    public class RuntimeServices : ICanBindRuntimeServices
    {
        readonly HeadsService _headsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RuntimeServices"/> class.
        /// </summary>
        /// <param name="headsService">Instance of <see cref="HeadsService"/>.</param>
        public RuntimeServices(HeadsService headsService)
        {
            _headsService = headsService;
        }

        /// <inheritdoc/>
        public ServiceAspect Aspect => "Application";

        /// <inheritdoc/>
        public IEnumerable<Service> BindServices() =>
            new Service[]
            {
                new Service(_headsService, contracts::Dolittle.Runtime.Heads.Heads.BindService(_headsService), contracts::Dolittle.Runtime.Heads.Heads.Descriptor)
            };
    }
}