/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Prometheus;

namespace Dolittle.Runtime.Metrics
{
    /// <summary>
    /// Defines a system for providing metric collectors
    /// </summary>
    public interface IMetricProviders
    {
        /// <summary>
        /// Provide all collectors of metrics in the system
        /// </summary>
        /// <returns><see cref="IEnumerable{T}">Collection</see></returns>
        IEnumerable<Collector> Provide();
    }
}