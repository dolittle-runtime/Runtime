/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Grpc.Core;

namespace Dolittle.Runtime.Application
{
    /// <summary>
    /// Represents an implementation of <see cref="IClientFor{T}"/>
    /// </summary>
    public class ClientFor<T> : IClientFor<T> where T : ClientBase
    {
        readonly IClients _clients;
        T _instance;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clients"></param>
        public ClientFor(IClients clients)
        {
            _clients = clients;
        }

        /// <inheritdoc/>
        public T Instance
        {
            get
            {
                if (_instance == null)
                {
                    var type = typeof(T);
                    var client = _clients.GetFor(type);
                    var constructor = type.GetConstructor(new Type[]  {  typeof(Channel) });
                    _instance = constructor.Invoke(new [] { client.Channel }) as T;
                }
                return _instance;
            }
        }
    }
}