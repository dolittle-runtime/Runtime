// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading;
using System.Threading.Tasks;
using Dolittle.Runtime.Events.Store.Streams.Filters;

namespace Dolittle.Runtime.Events.Processing.Filters
{
    /// <summary>
    /// Defines a system that compares a Filter with the persisted Filter and Stream generated from that Filter.
    /// </summary>
    public interface IValidateFilterByComparingStreams
    {
        /// <summary>
        /// Validate a Filter by comparing the generated Streams.
        /// </summary>
        /// <typeparam name="TFilterDefinition">The <see cref="IFilterDefinition" /> type.</typeparam>
        /// <param name="persistedDefinition">The persisted <see cref="IFilterDefinition " />.</param>
        /// <param name="filter">The <see cref="IFilterProcessor{TDefinition}" />.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" />.</param>
        /// <returns>A <see cref="Task" /> that, when resolved, returns the <see cref="FilterValidationResult" />. </returns>
        Task<FilterValidationResult> Validate<TFilterDefinition>(IFilterDefinition persistedDefinition, IFilterProcessor<TFilterDefinition> filter, CancellationToken cancellationToken)
            where TFilterDefinition : IFilterDefinition;
    }
}
