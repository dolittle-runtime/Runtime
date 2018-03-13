﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2008-2017 Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using Dolittle.Rules;

namespace Dolittle.Queries.Validation
{
    /// <summary>
    /// Represents the result of query argument validation, typically done by <see cref="IQueryValidator"/>
    /// </summary>
    public class QueryArgumentValidationResult 
    {
        /// <summary>
        /// Initializes an instance of <see cref="QueryArgumentValidationResult"/>
        /// </summary>
        /// <param name="brokenRules">Broken rules</param>
        public QueryArgumentValidationResult(IEnumerable<BrokenRule> brokenRules)
        {
            BrokenRules = brokenRules ?? new BrokenRule[0];
        }
        /// <summary>
        /// Gets all the broken rules
        /// </summary>
        public IEnumerable<BrokenRule> BrokenRules { get; private set; }

        /// <summary>
        /// Gets wether or not the validation was successful
        /// </summary>
        public bool Success { get { return BrokenRules.Count() == 0; } }
    }
}
