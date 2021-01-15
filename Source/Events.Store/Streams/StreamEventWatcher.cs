// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Dolittle.Lifecycle;

namespace Dolittle.Runtime.Events.Store.Streams
{
    /// <summary>
    /// Represents an implementation of <see cref="INotifyOfStreamEvents" /> and <see cref="IWaitForEventInStream" />.
    /// </summary>
    [SingletonPerTenant]
    public class StreamEventWatcher : INotifyOfStreamEvents, IWaitForEventInStream, INotifyOfPublicStreamEvents, IWaitForEventInPublicStream
    {
        readonly ConcurrentDictionary<EventWaiterId, EventWaiter> _waiters = new ConcurrentDictionary<EventWaiterId, EventWaiter>();
        readonly ConcurrentDictionary<EventWaiterId, EventWaiter> _publicWaiters = new ConcurrentDictionary<EventWaiterId, EventWaiter>();

        /// <inheritdoc/>
        public void NotifyForEvent(ScopeId scope, StreamId stream, StreamPosition position)
            => NotifyForEvent(scope, stream, position, false);

        /// <inheritdoc/>
        public Task WaitForEvent(ScopeId scope, StreamId stream, StreamPosition position, CancellationToken token)
            => WaitForWaiter(scope, stream, position, TimeSpan.FromMinutes(1), false, token);

        /// <inheritdoc/>
        public Task WaitForEvent(ScopeId scope, StreamId stream, StreamPosition position, TimeSpan timeout, CancellationToken token)
            => WaitForWaiter(scope, stream, position, timeout, false, token);

        /// <inheritdoc/>
        public void NotifyForEvent(StreamId stream, StreamPosition position)
            => NotifyForEvent(ScopeId.Default, stream, position, true);

        /// <inheritdoc/>
        public Task WaitForEvent(StreamId stream, StreamPosition position, CancellationToken token)
            => WaitForWaiter(ScopeId.Default, stream, position, TimeSpan.FromMinutes(1), true, token);

        /// <inheritdoc/>
        public Task WaitForEvent(StreamId stream, StreamPosition position, TimeSpan timeout, CancellationToken token)
            => WaitForWaiter(ScopeId.Default, stream, position, timeout, true, token);

        static EventWaiter CreateNewWaiter(EventWaiterId id)
            => new EventWaiter(id.Scope, id.Stream);

        async Task WaitForWaiter(ScopeId scope, StreamId stream, StreamPosition position, TimeSpan timeout, bool isPublic, CancellationToken token)
        {
            var waiterId = new EventWaiterId(scope, stream);
            using var timeoutSource = new CancellationTokenSource(timeout);
            using var linkedSource = CancellationTokenSource.CreateLinkedTokenSource(token, timeoutSource.Token);
            var waiter = isPublic
                ? _publicWaiters.GetOrAdd(waiterId, CreateNewWaiter)
                : _waiters.GetOrAdd(waiterId, CreateNewWaiter);

            await waiter.Wait(position, linkedSource.Token).ConfigureAwait(false);
        }

        void NotifyForEvent(ScopeId scope, StreamId stream, StreamPosition position, bool isPublic)
        {
            var waiterId = new EventWaiterId(scope, stream);
            var waiter = isPublic
                ? _publicWaiters.GetOrAdd(waiterId, CreateNewWaiter)
                : _waiters.GetOrAdd(waiterId, CreateNewWaiter);
            waiter.Notify(position);
        }
    }
}