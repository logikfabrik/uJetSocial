// <copyright file="CommentsApiController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.UI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using Comment.Querying;
    using global::Umbraco.Web.Editors;
    using global::Umbraco.Web.Mvc;
    using Models;
    using Querying;

    /// <summary>
    /// The <see cref="CommentsApiController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]
    public class CommentsApiController : UmbracoAuthorizedJsonController
    {
        private readonly QueryableEntityProvider<Comment.Comment, ICommentCriteria, ICommentSortOrder> _commentProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsApiController" /> class.
        /// </summary>
        /// <param name="entityProviderFactory">The entity provider factory.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="entityProviderFactory" /> is <c>null</c>.</exception>
        public CommentsApiController(IEntityProviderFactory entityProviderFactory)
        {
            if (entityProviderFactory == null)
            {
                throw new ArgumentNullException(nameof(entityProviderFactory));
            }

            _commentProvider = entityProviderFactory.GetEntityProvider(typeof(Comment.Comment)) as QueryableEntityProvider<Comment.Comment, ICommentCriteria, ICommentSortOrder>;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsApiController" /> class.
        /// </summary>
        public CommentsApiController()
            : this(EntityProviderFactory.Instance)
        {
        }

        [HttpPost]
        public SearchQueryResult<Comment.Comment> Search(CommentSearchQuery searchQuery)
        {
            if (searchQuery == null)
            {
                throw new ArgumentNullException(nameof(searchQuery));
            }

            var query = new CommentQuery
            {
                SortOrder = new CommentCreatedSortOrder(Order.Ascending),
                PageIndex = searchQuery.PageIndex,
                PageSize = searchQuery.PageSize
            };

            if (searchQuery.From.HasValue && searchQuery.To.HasValue)
            {
                var fromToCriteria = new CommentCreatedCriteria
                {
                    Value =
                        new NumericRangeCriteriaValue<DateTime>
                        {
                            MinValue = searchQuery.From.Value,
                            MaxValue = searchQuery.To.Value,
                            Operator = NumericRangeCriteriaValueOperator.Between
                        }
                };

                query.Criterias.Add(fromToCriteria);
            }
            else
            {
                if (searchQuery.From.HasValue)
                {
                    var fromCriteria = new CommentCreatedCriteria
                    {
                        Value =
                            new NumericCriteriaValue<DateTime>
                            {
                                Value = searchQuery.From.Value,
                                Operator = NumericCriteriaValueOperator.LargerThan
                            }
                    };

                    query.Criterias.Add(fromCriteria);
                }

                if (searchQuery.To.HasValue)
                {
                    var toCriteria = new CommentCreatedCriteria
                    {
                        Value =
                            new NumericCriteriaValue<DateTime>
                            {
                                Value = searchQuery.To.Value,
                                Operator = NumericCriteriaValueOperator.LessThan
                            }
                    };

                    query.Criterias.Add(toCriteria);
                }
            }

            int total;

            var comments = _commentProvider.Query(query, out total);

            return new SearchQueryResult<Comment.Comment> { Total = total, Entities = comments };
        }

        /// <summary>
        /// Gets the possible orders.
        /// </summary>
        /// <returns>The possible orders.</returns>
        [HttpGet]
        public IEnumerable<string> GetPossibleOrders()
        {
            return new[]
            {
                typeof(CommentAuthorIdSortOrder).Name,
                typeof(CommentCreatedSortOrder).Name,
                typeof(CommentEntityIdSortOrder).Name,
                typeof(CommentIdSortOrder).Name,
                typeof(CommentStatusSortOrder).Name,
                typeof(CommentTextSortOrder).Name,
                typeof(CommentUpdatedSortOrder).Name
            };
        }
    }
}
