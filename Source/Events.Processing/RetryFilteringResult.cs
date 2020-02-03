// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Dolittle.Runtime.Events.Processing
{
    /// <summary>
    /// Represents an implementation of <see cref="IFilterResult" /> where filtering failed and it should try to filter again.
    /// </summary>
    public class RetryFilteringResult : IFilterResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetryFilteringResult"/> class.
        /// </summary>
        /// <param name="retryTimeout">The retry timeout in milliseconds.</param>
        public RetryFilteringResult(int retryTimeout) => RetryTimeout = retryTimeout;

        /// <inheritdoc />
        public bool Succeeded => false;

        /// <inheritdoc />
        public bool Retry => true;

        /// <inheritdoc />
        public bool IsIncluded => false;

        /// <inheritdoc />
        public PartitionId Partition => PartitionId.Empty;

        /// <summary>
        /// Gets the timeout when retrying.
        /// </summary>
        public int RetryTimeout { get; }
    }
}