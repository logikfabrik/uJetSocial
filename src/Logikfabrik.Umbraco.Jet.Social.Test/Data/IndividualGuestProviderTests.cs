// <copyright file="IndividualGuestProviderTests.cs" company="Logikfabrik">
//  Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Test.Data
{
    using System;
    using System.Linq;
    using global::Umbraco.Core.Logging;
    using global::Umbraco.Core.Persistence.SqlSyntax;
    using Individual;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class IndividualGuestProviderTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            SqlSyntaxContext.SqlSyntaxProvider = new SqlServerSyntaxProvider();
        }

        [TestMethod]
        public void CanGetIndividualGuest()
        {
            var provider = new IndividualGuestProvider(GetDatabaseWrapper());

            var dto = new IndividualGuest
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "firstname.lastname@isp.com"
            };

            var id = provider.Add(dto);

            Assert.IsNotNull(provider.Get(id));
        }

        [TestMethod]
        public void CanAddIndividualGuest()
        {
            var provider = new IndividualGuestProvider(GetDatabaseWrapper());

            var dto = new IndividualGuest
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "firstname.lastname@isp.com"
            };

            var id = provider.Add(dto);

            Assert.IsNotNull(provider.Get(id));
        }

        [TestMethod]
        public void CanQueryIndividualGuest()
        {
            var provider = new IndividualGuestProvider(GetDatabaseWrapper());

            var query = new Query<IndividualGuest>(0, 10);

            query.Criterias.Add(c => c.FirstName == "FirstName");

            Assert.IsTrue(provider.Query(query).Any());
        }

        [TestMethod]
        public void CanRemoveIndividualGuest()
        {
            var provider = new IndividualGuestProvider(GetDatabaseWrapper());

            var dto = new IndividualGuest
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "firstname.lastname@isp.com"
            };

            var id = provider.Add(dto);

            provider.Remove(id);

            Assert.IsNull(provider.Get(id));
        }

        [TestMethod]
        public void CanUpdateIndividualGuest()
        {
            throw new NotImplementedException();
        }

        private static IDatabaseWrapper GetDatabaseWrapper()
        {
            var db = new global::Umbraco.Core.Persistence.Database("Test");

            return new DatabaseWrapper(db, new Mock<ILogger>().Object, SqlSyntaxContext.SqlSyntaxProvider);
        }
    }
}
