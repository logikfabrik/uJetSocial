// <copyright file="IndividualMemberAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System.Web.Http;
    using global::Umbraco.Web.Mvc;
    using Individual;

    /// <summary>
    /// The <see cref="IndividualMemberAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class IndividualMemberAPIController : DataTransferObjectAPIController<IndividualMember>
    {
        [HttpGet]
        public IndividualMember GetByMemberId(int id)
        {
            var provider = (IIndividualMemberProvider)Provider;

            var member = provider.GetByMemberId(id);

            return member ?? provider.Add(new IndividualMember { MemberId = id });
        }
    }
}
