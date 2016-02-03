// <copyright file="IndividualGuestProviderTests.cs" company="Logikfabrik">
//  Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Test.Data
{
    using System;
    using System.Linq;
    using Individual;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IndividualGuestProviderTests : TestBase
    {
        public override void TestInitialize()
        {
            base.TestInitialize();

            var database = GetDatabase();

            if (DataTransferObjectProviders.GetProvider(typeof(IndividualGuest)) == null)
            {
                DataTransferObjectProviders.Providers.Add(typeof(IndividualGuest), new IndividualGuestProvider(database));
            }
        }

        [TestMethod]
        public void CanGetIndividualGuest()
        {
            var dto = new IndividualGuest
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "firstname.lastname@isp.com"
            };

            var provider = (IDataTransferObjectProvider<IndividualGuest>)DataTransferObjectProviders.GetProvider(typeof(IndividualGuest));

            var id = provider.Add(dto).Id;

            Assert.IsNotNull(provider.Get(id));
        }

        [TestMethod]
        public void CanAddIndividualGuest()
        {
            var dto = new IndividualGuest
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "firstname.lastname@isp.com"
            };

            var provider = (IDataTransferObjectProvider<IndividualGuest>)DataTransferObjectProviders.GetProvider(typeof(IndividualGuest));

            Assert.IsNotNull(provider.Add(dto));
        }

        [TestMethod]
        public void CanQueryIndividualGuest()
        {
            var query = new Query<IndividualGuest>(0, 10);

            query.Criterias.Add(c => c.FirstName == "FirstName");

            var provider = (IDataTransferObjectProvider<IndividualGuest>)DataTransferObjectProviders.GetProvider(typeof(IndividualGuest));

            Assert.IsTrue(provider.Query(query).Objects.Any());
        }

        [TestMethod]
        public void CanRemoveIndividualGuest()
        {
            var dto = new IndividualGuest
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "firstname.lastname@isp.com"
            };

            var provider = (IDataTransferObjectProvider<IndividualGuest>)DataTransferObjectProviders.GetProvider(typeof(IndividualGuest));

            var id = provider.Add(dto).Id;

            provider.Remove(id);

            Assert.IsNull(provider.Get(id));
        }

        [TestMethod]
        public void CanUpdateIndividualGuestFirstName()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void CanUpdateIndividualGuestLastName()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void CanUpdateIndividualGuestEmail()
        {
            throw new NotImplementedException();
        }
    }
}
