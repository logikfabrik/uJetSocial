// <copyright file="IndividualGuestTests.cs" company="Logikfabrik">
//  Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Test.Data
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Social.Data;

    [TestClass]
    public class IndividualGuestTests
    {
        [TestMethod]
        public void CanSetFirstNameWhenNotReadOnly()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var dto = new IndividualGuest { IsReadOnly = false };

            dto.FirstName = "FirstName";
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CanNotSetFirstNameWhenReadOnly()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var dto = new IndividualGuest { IsReadOnly = true };

            dto.FirstName = "FirstName";
        }

        [TestMethod]
        public void CanSetLastNameWhenNotReadOnly()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var dto = new IndividualGuest { IsReadOnly = false };

            dto.LastName = "LastName";
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CanNotSetLastNameWhenReadOnly()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var dto = new IndividualGuest { IsReadOnly = true };

            dto.LastName = "LastName";
        }

        [TestMethod]
        public void CanSetEmailWhenNotReadOnly()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var dto = new IndividualGuest { IsReadOnly = false };

            dto.Email = "Email";
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CanNotSetEmailWhenReadOnly()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var dto = new IndividualGuest { IsReadOnly = true };

            dto.Email = "Email";
        }

        [TestMethod]
        public void CanGetWritableClone()
        {
            var dto = new IndividualGuest();

            Assert.IsNotNull(dto.CreateWritableClone());
        }

        [TestMethod]
        public void CanGetFirstNameFromWritableClone()
        {
            var dto = new IndividualGuest { FirstName = "FirstName" };

            Assert.AreEqual(dto.FirstName, dto.CreateWritableClone().FirstName);
        }

        [TestMethod]
        public void CanGetLastNameFromWritableClone()
        {
            var dto = new IndividualGuest { LastName = "LastName" };

            Assert.AreEqual(dto.LastName, dto.CreateWritableClone().LastName);
        }

        [TestMethod]
        public void CanGetEmailFromWritableClone()
        {
            var dto = new IndividualGuest { Email = "Email" };

            Assert.AreEqual(dto.Email, dto.CreateWritableClone().Email);
        }
    }
}
