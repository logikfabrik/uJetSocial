// <copyright file="DocumentAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System.Web.Http;
    using Document;
    using global::Umbraco.Web.Mvc;

    /// <summary>
    /// The <see cref="DocumentAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class DocumentAPIController : DataTransferObjectAPIController<Document>
    {
        [HttpGet]
        public Document GetByDocumentId(int id)
        {
            var provider = (IDocumentProvider)Provider;

            var document = provider.GetByUmbracoId(id);

            return document ?? provider.Add(new Document { DocumentId = id });
        }
    }
}
