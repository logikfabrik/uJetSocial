// <copyright file="CommentProviderTests.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Test.Data
{
    using Comment;
    using global::Umbraco.Core.Logging;
    using global::Umbraco.Core.Persistence.SqlSyntax;
    using Individual;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class CommentProviderTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            SqlSyntaxContext.SqlSyntaxProvider = new SqlServerSyntaxProvider();
        }

        [TestMethod]
        public void CanGetComment()
        {
            var provider = new CommentProvider(GetDatabaseWrapper());

            var dto = new Comment
            {
                EntityId = GetIndividualGuest().Id,
                AuthorId = GetIndividualGuest().Id,
                Text = "HEJ"
            };

            var id = provider.Add(dto);

            var comment = provider.Get(id);
            
            var d = 0;
        }

        private Individual GetIndividualGuest()
        {
            var provider = new IndividualGuestProvider(GetDatabaseWrapper());

            var dto = new IndividualGuest
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "firstname.lastname@isp.com"
            };

            var id = provider.Add(dto);

            return provider.Get(id);
        }

        private static IDatabaseWrapper GetDatabaseWrapper()
        {
            var db = new global::Umbraco.Core.Persistence.Database("Test");

            return new DatabaseWrapper(db, new Mock<ILogger>().Object, SqlSyntaxContext.SqlSyntaxProvider);
        }
    }
}
