// <copyright file="ForeignKeyAttribute.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;

    /// <summary>
    /// The <see cref="ForeignKeyAttribute" /> class.
    /// </summary>
    public class ForeignKeyAttribute : global::Umbraco.Core.Persistence.DatabaseAnnotations.ForeignKeyAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForeignKeyAttribute" /> class.
        /// </summary>
        /// <param name="typeName">The type name.</param>
        public ForeignKeyAttribute(string typeName)
            : base(Type.GetType(typeName, true))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForeignKeyAttribute" /> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public ForeignKeyAttribute(Type type)
            : base(type)
        {
        }
    }
}
