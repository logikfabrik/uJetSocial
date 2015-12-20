// <copyright file="GuestAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System.Web.Http;
    using global::Umbraco.Web.Editors;
    using global::Umbraco.Web.Mvc;
    using Individual;

    [PluginController("uJetSocial")]
    public class GuestAPIController : UmbracoAuthorizedJsonController
    {
        private readonly IndividualProvider<IndividualGuest> _provider;

        public GuestAPIController()
        {
            _provider = DataTransferObjectProviders.GetProvider(typeof(IndividualGuest)) as IndividualProvider<IndividualGuest>;
        }

        [HttpPost]
        public SearchQueryResult<IndividualGuest> Search(SearchQuery searchQuery)
        {
            var items = _provider.Query(new Query<IndividualGuest>(1, 10));

            return new SearchQueryResult<IndividualGuest>
            {
                Entities = items,
                Total = 100
            };
        }

        public void Add(IndividualGuest dto)
        {
            _provider.Add(dto);
        }

        public void Edit(IndividualGuest dto)
        {
            _provider.Update(dto);
        }
    }
}
