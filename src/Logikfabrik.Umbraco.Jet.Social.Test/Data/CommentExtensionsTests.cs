// <copyright file="CommentExtensionsTests.cs" company="Logikfabrik">
//  Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Test.Data
{
    using System;
    using Comment;
    using Individual;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommentExtensionsTests : TestBase
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            var database = GetDatabase();

            if (DataTransferObjectProviders.GetProvider(typeof(Comment)) == null)
            {
                DataTransferObjectProviders.Providers.Add(typeof(Comment), new CommentProvider(database));
            }

            if (DataTransferObjectProviders.GetProvider(typeof(IndividualGuest)) == null)
            {
                DataTransferObjectProviders.Providers.Add(typeof(IndividualGuest), new IndividualGuestProvider(database));
            }
        }

        private static Individual GetIndividualGuest()
        {
            var provider = (IDataTransferObjectProvider<IndividualGuest>)DataTransferObjectProviders.GetProvider(typeof(IndividualGuest));

            var dto = new IndividualGuest
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "firstname.lastname@isp.com"
            };

            var id = provider.Add(dto);

            return provider.Get(id);
        }

        private static Comment GetComment()
        {
            var provider = (IDataTransferObjectProvider<Comment>)DataTransferObjectProviders.GetProvider(typeof(Comment));

            var dto = new Comment
            {
                EntityId = GetIndividualGuest().Id,
                AuthorId = GetIndividualGuest().Id,
                Text = "Text"
            };

            var id = provider.Add(dto);

            return provider.Get(id);
        }

        [TestMethod]
        public void CanGetEntity()
        {
            var comment = GetComment();

            var entity = comment.GetEntity();

            Assert.IsNotNull(entity);
        }

        [TestMethod]
        public void CanSetEntity()
        {
            var comment = GetComment().CreateWritableClone();

            var entity = GetIndividualGuest();

            comment.SetEntity(entity);

            Assert.AreEqual(entity.Id, comment.EntityId);
            Assert.AreEqual(entity.GetType().AssemblyQualifiedName, comment.EntityType.AssemblyQualifiedName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CanNotSetEntity()
        {
            var comment = GetComment();

            var entity = GetIndividualGuest();

            comment.SetEntity(entity);
        }

        [TestMethod]
        public void CanGetAuthor()
        {
            var comment = GetComment();

            var author = comment.GetAuthor();

            Assert.IsNotNull(author);
        }

        [TestMethod]
        public void CanSetAuthor()
        {
            var comment = GetComment().CreateWritableClone();

            var author = GetIndividualGuest();

            comment.SetAuthor(author);

            Assert.AreEqual(author.Id, comment.AuthorId);
            Assert.AreEqual(author.GetType().AssemblyQualifiedName, comment.AuthorType.AssemblyQualifiedName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CanNotSetAuthor()
        {
            var comment = GetComment();

            var author = GetIndividualGuest();

            comment.SetAuthor(author);
        }
    }
}
