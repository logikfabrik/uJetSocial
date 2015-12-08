using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logikfabrik.Umbraco.Jet.Social.Comment;
using Logikfabrik.Umbraco.Jet.Social.Individual;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Umbraco.Core.Logging;
using Umbraco.Core.Persistence.SqlSyntax;

namespace Logikfabrik.Umbraco.Jet.Social.Test.Data
{
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

            var dto = new Comment.Comment
            {
                EntityId = GetIndividualGuest().Id,
                AuthorId = GetIndividualGuest().Id,
                Text = "HEJ"
            };

            var id = provider.Add(dto);

            var comment = provider.Get(id);
            
            var d = 0;
        }

        private Individual.Individual GetIndividualGuest()
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
