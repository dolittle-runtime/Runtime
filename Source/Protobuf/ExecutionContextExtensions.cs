/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Globalization;
using Dolittle.Applications;
using Dolittle.Collections;
using Dolittle.Events.Relativity.Microservice;
using Dolittle.Tenancy;
using Dolittle.Protobuf;

namespace Dolittle.Runtime.Protobuf
{
    /// <summary>
    /// Extensions for converting <see cref="ExecutionContext"/> to and from protobuf representations
    /// </summary>
    public static class ExecutionContextExtensions
    {
        /// <summary>
        /// Convert from <see cref="ExecutionContext"/> to <see cref="Dolittle.Execution.ExecutionContext"/>
        /// </summary>
        /// <param name="protobuf"><see cref="ExecutionContext"/> to convert from</param>
        /// <returns>Converted <see cref="Dolittle.Execution.ExecutionContext"/></returns>
        public static Execution.ExecutionContext ToExecutionContext(this ExecutionContext protobuf)
        {
            return new Execution.ExecutionContext(
                protobuf.Application.To<Application>(),
                protobuf.BoundedContext.To<BoundedContext>(),
                protobuf.Tenant.To<TenantId>(),
                protobuf.Environment,
                protobuf.CorrelationId.To<Dolittle.Execution.CorrelationId>(),
                protobuf.Claims.ToClaims(),
                CultureInfo.GetCultureInfo(protobuf.Culture)
            );
        }

        /// <summary>
        /// Convert from <see cref="Dolittle.Execution.ExecutionContext"/> to <see cref="ExecutionContext"/>
        /// </summary>
        /// <param name="executionContext"><see cref="Dolittle.Execution.ExecutionContext"/> to convert from</param>
        /// <returns>Converted <see cref="ExecutionContext"/></returns>
        public static ExecutionContext ToProtobuf(this Execution.ExecutionContext executionContext)
        {
            var protobuf = new ExecutionContext
            {
                Application = Extensions.ToProtobuf(executionContext.Application),
                BoundedContext = Extensions.ToProtobuf(executionContext.BoundedContext),
                Tenant = Extensions.ToProtobuf(executionContext.Tenant),
                CorrelationId = Extensions.ToProtobuf(executionContext.CorrelationId),
                Environment = executionContext.Environment.Value,
                Culture = executionContext.Culture?.Name ?? CultureInfo.InvariantCulture.Name
            };
            executionContext.Claims.ToProtobuf().ForEach(protobuf.Claims.Add);
            return protobuf;
        }
    }
}