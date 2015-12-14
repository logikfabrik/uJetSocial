// <copyright file="MemberProviderTests.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Test.Data
{
    using Member;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MemberProviderTests : TestBase
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            var database = GetDatabase();

            if (DataTransferObjectProviders.GetProvider(typeof(Member)) == null)
            {
                DataTransferObjectProviders.Providers.Add(typeof(Member), new MemberProvider(database));
            }
        }

        [TestMethod]
        public void CanAddMember()
        {
            var dto = new Member
            {
                MemberId = 3
            };

            var provider = (IDataTransferObjectProvider<Member>)DataTransferObjectProviders.GetProvider(typeof(Member));

            Assert.IsNotNull(provider.Add(dto));
        }
    }
}
