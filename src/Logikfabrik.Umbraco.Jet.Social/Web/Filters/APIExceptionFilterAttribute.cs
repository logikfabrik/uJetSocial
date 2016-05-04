// <copyright file="APIExceptionFilterAttribute.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Filters
{
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Web.Http;
    using System.Web.Http.Filters;
    using Models;

    // TODO: Use this filter and AngularJS HTTP interceptor.

    /// <summary>
    /// The <see cref="APIExceptionFilterAttribute" /> class.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class APIExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Called when an exception occurs in an API controller.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            var ex = context.Exception;

            var response = new HttpResponseMessage
            {
                Content = new ObjectContent<APIException>(
                    new APIException
                    {
                        Message = ex.Message,
                        Source = ex.Source,
                        StackTrace = ex.StackTrace
                    }, new JsonMediaTypeFormatter())
            };

            throw new HttpResponseException(response);
        }
    }
}
