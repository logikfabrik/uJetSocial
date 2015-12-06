// <copyright file="IndividualGuestProviderTests.cs" company="Logikfabrik">
//  Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Test.Data
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Social.Data;

    [TestClass]
    public class IndividualGuestProviderTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            global::Umbraco.Core.Persistence.SqlSyntax.SqlSyntaxContext.SqlSyntaxProvider = new global::Umbraco.Core.Persistence.SqlSyntax.SqlServerSyntaxProvider();
        }

        [TestMethod]
        public void CanGetIndividualGuest()
        {
            var db = new global::Umbraco.Core.Persistence.Database("Test");

            var provider = new IndividualGuestProvider(db);

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
            var db = new global::Umbraco.Core.Persistence.Database("Test");

            var provider = new IndividualGuestProvider(db);

            var dto = new IndividualGuest
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "firstname.lastname@isp.com"
            };

            var id = provider.Add(dto);

            Assert.IsNotNull(provider.Get(id));
        }
    }
}
