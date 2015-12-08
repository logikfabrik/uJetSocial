// <copyright file="TestBase.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Test.Data
{
    using global::Umbraco.Core.Logging;
    using global::Umbraco.Core.Persistence.SqlSyntax;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    public abstract class TestBase
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            SqlSyntaxContext.SqlSyntaxProvider = new SqlServerSyntaxProvider();
        }

        protected static IDatabaseWrapper GetDatabase()
        {
            var db = new global::Umbraco.Core.Persistence.Database("Test");

            return new DatabaseWrapper(db, new Mock<ILogger>().Object, SqlSyntaxContext.SqlSyntaxProvider);
        }
    }
}
