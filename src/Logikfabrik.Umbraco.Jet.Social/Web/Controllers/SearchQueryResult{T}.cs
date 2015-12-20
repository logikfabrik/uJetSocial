// <copyright file="SearchQueryResult{T}.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public class SearchQueryResult<T> where T : DataTransferObject
    {
        [DataMember(Name = "total")]
        public int Total { get; set; }

        [DataMember(Name = "entities")]
        public IEnumerable<T> Entities { get; set; }
    }
}
