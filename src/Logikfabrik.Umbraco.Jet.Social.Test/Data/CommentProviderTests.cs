// <copyright file="CommentProviderTests.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Test.Data
{
    using System;
    using Comment;
    using Individual;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommentProviderTests : TestBase
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

            return provider.Add(dto);
        }

        [TestMethod]
        public void CanGetComment()
        {
            var dto = new Comment
            {
                EntityId = GetIndividualGuest().Id,
                EntityType = typeof(IndividualGuest),
                AuthorId = GetIndividualGuest().Id,
                AuthorType = typeof(IndividualGuest),
                Text = "Text"
            };

            var provider = (IDataTransferObjectProvider<Comment>)DataTransferObjectProviders.GetProvider(typeof(Comment));

            var id = provider.Add(dto).Id;

            Assert.IsNotNull(provider.Get(id));
        }

        [TestMethod]
        public void CanAddComment()
        {
            var dto = new Comment
            {
                EntityId = GetIndividualGuest().Id,
                EntityType = typeof(IndividualGuest),
                AuthorId = GetIndividualGuest().Id,
                AuthorType = typeof(IndividualGuest),
                Text = "Text"
            };

            var provider = (IDataTransferObjectProvider<Comment>)DataTransferObjectProviders.GetProvider(typeof(Comment));

            Assert.IsNotNull(provider.Add(dto));
        }

        [TestMethod]
        public void CanRemoveComment()
        {
            var dto = new Comment
            {
                EntityId = GetIndividualGuest().Id,
                EntityType = typeof(IndividualGuest),
                AuthorId = GetIndividualGuest().Id,
                AuthorType = typeof(IndividualGuest),
                Text = "Text"
            };

            var provider = (IDataTransferObjectProvider<Comment>)DataTransferObjectProviders.GetProvider(typeof(Comment));

            var id = provider.Add(dto).Id;

            provider.Remove(id);

            Assert.IsNull(provider.Get(id));
        }

        [TestMethod]
        public void CanUpdateCommentEntityId()
        {
            var dto1 = new Comment
            {
                EntityId = GetIndividualGuest().Id,
                EntityType = typeof(IndividualGuest),
                AuthorId = GetIndividualGuest().Id,
                AuthorType = typeof(IndividualGuest),
                Text = "Text"
            };

            var provider = (IDataTransferObjectProvider<Comment>)DataTransferObjectProviders.GetProvider(typeof(Comment));

            var dto2 = provider.Add(dto1).CreateWritableClone();

            dto2.SetEntity(GetIndividualGuest());

            var dto3 = provider.Update(dto2);

            Assert.AreNotEqual(dto1.EntityId, dto3.EntityId);
        }

        [TestMethod]
        public void CanUpdateCommentAuthorId()
        {
            var dto1 = new Comment
            {
                EntityId = GetIndividualGuest().Id,
                EntityType = typeof(IndividualGuest),
                AuthorId = GetIndividualGuest().Id,
                AuthorType = typeof(IndividualGuest),
                Text = "Text"
            };

            var provider = (IDataTransferObjectProvider<Comment>)DataTransferObjectProviders.GetProvider(typeof(Comment));

            var dto2 = provider.Add(dto1).CreateWritableClone();

            dto2.SetAuthor(GetIndividualGuest());

            var dto3 = provider.Update(dto2);

            Assert.AreNotEqual(dto1.AuthorId, dto3.AuthorId);
        }

        [TestMethod]
        public void CanUpdateCommentText()
        {
            throw new NotImplementedException();
        }
    }
}
