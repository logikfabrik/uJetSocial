// <copyright file="CommentTests.cs" company="Logikfabrik">
//  Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Test.Data
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommentTests
    {
        [TestMethod]
        public void CanSetEntityIdWhenNotReadOnly()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var dto = new Comment.Comment { IsReadOnly = false };

            dto.EntityId = 123;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CanNotSetEntityIdWhenReadOnly()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var dto = new Comment.Comment { IsReadOnly = true };

            dto.EntityId = 123;
        }

        [TestMethod]
        public void CanSetAuthorIdWhenNotReadOnly()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var dto = new Comment.Comment { IsReadOnly = false };

            dto.AuthorId = 123;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CanNotSetAuthorIdWhenReadOnly()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var dto = new Comment.Comment { IsReadOnly = true };

            dto.AuthorId = 123;
        }

        [TestMethod]
        public void CanSetTextWhenNotReadOnly()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var dto = new Comment.Comment { IsReadOnly = false };

            dto.Text = "Text";
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CanNotSetTextWhenReadOnly()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var dto = new Comment.Comment { IsReadOnly = true };

            dto.Text = "Text";
        }

        [TestMethod]
        public void CanGetWritableClone()
        {
            var dto = new Comment.Comment();

            Assert.IsNotNull(dto.CreateWritableClone());
        }

        [TestMethod]
        public void CanGetEntityIdFromWritableClone()
        {
            var dto = new Comment.Comment { EntityId = 123 };

            Assert.AreEqual(dto.EntityId, dto.CreateWritableClone().EntityId);
        }

        [TestMethod]
        public void CanGetAuthorIdFromWritableClone()
        {
            var dto = new Comment.Comment { AuthorId = 123 };

            Assert.AreEqual(dto.AuthorId, dto.CreateWritableClone().AuthorId);
        }

        [TestMethod]
        public void CanGetTextFromWritableClone()
        {
            var dto = new Comment.Comment { Text = "Text" };

            Assert.AreEqual(dto.Text, dto.CreateWritableClone().Text);
        }
    }
}
