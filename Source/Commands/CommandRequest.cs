﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2008-2017 Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.Applications;
using Dolittle.Runtime.Transactions;

namespace Dolittle.Runtime.Commands
{
    /// <summary>
    /// Represents a request for executing a command
    /// </summary>
    public class CommandRequest
    {
        /// <summary>
        /// Initializes a new instance of <see cref="CommandRequest"/>
        /// </summary>
        /// <param name="correlationId"><see cref="TransactionCorrelationId"/> for the transaction</param>
        /// <param name="type"><see cref="IApplicationArtifactIdentifier">Identifier</see> of the command</param>
        /// <param name="content">Content of the command</param>
        public CommandRequest(TransactionCorrelationId correlationId, IApplicationArtifactIdentifier type, IDictionary<string, object> content)
        {
            CorrelationId = correlationId;
            Type = type;
            Content = content;
        }

        /// <summary>
        /// Gets the <see cref="TransactionCorrelationId"/> representing the transaction
        /// </summary>
        /// <returns>The <see cref="TransactionCorrelationId"/></returns>
        public TransactionCorrelationId CorrelationId { get; }

        /// <summary>
        /// Gets the <see cref="IApplicationArtifactIdentifier"/> representing the type of the Command
        /// </summary>
        /// <returns>
        /// <see cref="IApplicationArtifactIdentifier"/> representing the type of the Command
        /// </returns>
        public IApplicationArtifactIdentifier   Type { get; }

        /// <summary>
        /// Gets the content of the command
        /// </summary>
        /// <returns>
        /// <see cref="IDictionary{TKey, TValue}">Content</see> of the command
        /// </returns>
        public IDictionary<string, object> Content { get; }
    }
}