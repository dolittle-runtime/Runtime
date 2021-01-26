// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Dolittle.Runtime.ApplicationModel;
using Dolittle.Runtime.Configuration;
using Dolittle.Runtime.ResourceTypes;

namespace Dolittle.Runtime.Applications.Configuration
{
    /// <summary>
    /// Represents the definition of a <see cref="Microservice"/> for configuration.
    /// </summary>
    [Name("bounded-context")]
    public class BoundedContextConfiguration : IConfigurationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoundedContextConfiguration"/> class.
        /// </summary>
        /// <param name="application"><see cref="Application"/> this belongs to.</param>
        /// <param name="boundedContext"><see cref="Microservice"/> running.</param>
        /// <param name="boundedContextName"><see cref="MicroserviceName" /> of microservice.</param>
        /// <param name="core">The <see cref="CoreConfiguration"/>.</param>
        /// <param name="interaction">The <see cref="InteractionLayerConfiguration"/>.</param>
        /// <param name="resources">Resource configurations for different types.</param>
        public BoundedContextConfiguration(
            Application application,
            Microservice boundedContext,
            MicroserviceName boundedContextName,
            CoreConfiguration core,
            IEnumerable<InteractionLayerConfiguration> interaction,
            IDictionary<ResourceType, ResourceTypeImplementationConfiguration> resources)
        {
            Application = application;
            BoundedContext = boundedContext;
            BoundedContextName = boundedContextName;
            Core = core;
            Interaction = interaction;
            Resources = resources;
        }

        /// <summary>
        /// Gets the <see cref="Application"/>.
        /// </summary>
        public Application Application { get; }

        /// <summary>
        /// Gets the <see cref="Microservice"/>.
        /// </summary>
        public Microservice BoundedContext { get; }

        /// <summary>
        /// Gets the <see cref="MicroserviceName"/>.
        /// </summary>
        public MicroserviceName BoundedContextName { get; }

        /// <summary>
        /// Gets the <see cref="CoreConfiguration"/>.
        /// </summary>
        public CoreConfiguration Core { get; }

        /// <summary>
        /// Gets the <see cref="InteractionLayerConfiguration"/> list.
        /// </summary>
        public IEnumerable<InteractionLayerConfiguration> Interaction { get; }

        /// <summary>
        /// Gets the Resource configurations.
        /// </summary>
        public IDictionary<ResourceType, ResourceTypeImplementationConfiguration> Resources { get; }
    }
}