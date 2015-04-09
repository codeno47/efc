// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="Specification.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="Specification.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using System;
using System.Data;
using System.Linq.Expressions;

namespace EFC.Components.Data
{
    /// <summary>
    /// Specification.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Specification<T>
    {
        #region Fields

        /// <summary>
        /// The expression predicate.
        /// </summary>
        private readonly Expression<Func<T, bool>> expression;

        /// <summary>
        /// Function to evaluate the expression against an instance.
        /// </summary>
        private Func<T, bool> evaluateExpression;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Specification class.
        /// </summary>
        /// <param name="predicate">Expression predicate.</param>
        public Specification(Expression<Func<T, bool>> predicate)
        {
            this.expression = predicate;
        }

        /// <summary>
        /// Initializes a new instance of the Specification class.
        /// </summary>
        protected Specification()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the expression predicate.
        /// </summary>
        /// <value>The expression predicate.</value>
        public virtual Expression<Func<T, bool>> Predicate
        {
            get
            {
                if (expression != null)
                {
                    return expression;
                }

                throw new InvalidExpressionException("Argument Predicate Not Overridden");
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Evaluates the specification against an instance.
        /// </summary>
        /// <param name="candidate">The instance against which the specificaton is to be evaluated.</param>
        /// <returns>Should return <c>true</c> if the specification was satisfied by the entity, else <c>false</c>.</returns>
        public bool IsSatisfiedBy(T candidate)
        {
            if (evaluateExpression == null)
            {
                evaluateExpression = expression.Compile();
            }

            return evaluateExpression(candidate);
        }

        #endregion
    }
}
