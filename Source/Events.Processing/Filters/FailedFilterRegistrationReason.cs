// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Dolittle.Concepts;
using Dolittle.Runtime.Events.Processing.Streams;

namespace Dolittle.Runtime.Events.Processing.Filters
{
    /// <summary>
    /// Represents the reason for why the registration of a filter failed.
    /// </summary>
    public class FailedFilterRegistrationReason : ConceptAs<string>
    {
        /// <summary>
        /// Gets a value indicating whether the <see cref="FailedFilterRegistrationReason" /> is set.
        /// </summary>
        /// <returns>True if set, false if not.</returns>
        public bool IsSet => !string.IsNullOrEmpty(Value);

        /// <summary>
        /// Creates a <see cref="FailedFilterRegistrationReason" /> from <see cref="StreamProcessorRegistrationResult" /> and <see cref="FilterValidationResult" />.
        /// </summary>
        /// <param name="filterProcessorRegistrationResult">The <see cref="StreamProcessorRegistrationResult" /> for the filter <see cref="StreamProcessor" />.</param>
        /// <param name="filterValidationResult">The <see cref="FilterValidationResult" />.</param>
        /// <returns>The <see cref="FailedFilterRegistrationReason" />.</returns>
        public static FailedFilterRegistrationReason FromRegistrationResults(
            StreamProcessorRegistrationResult filterProcessorRegistrationResult,
            FilterValidationResult filterValidationResult)
        {
            var value = string.Empty;
            value += filterProcessorRegistrationResult.Failed ?
                string.Empty
                : $"{(string.IsNullOrEmpty(value) ? string.Empty : "\n")}Stream Processor for filter with Stream Processor Id: '{filterProcessorRegistrationResult.StreamProcessor.Identifier}' has already been registered";

            value += filterValidationResult.Succeeded ?
                string.Empty
                : $"{(string.IsNullOrEmpty(value) ? string.Empty : "\n")}Filter validation failed. {filterValidationResult.FailureReason}";

            return new FailedFilterRegistrationReason { Value = value };
        }
    }
}
