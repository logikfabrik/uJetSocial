// <copyright file="IndividualGuestAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using global::Umbraco.Web.Mvc;
    using Individual;

    /// <summary>
    /// The <see cref="IndividualGuestAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class IndividualGuestAPIController : DataTransferObjectAPIController<IndividualGuest>
    {
    }
}
