// <copyright file="IndividualGuest.cs" company="Logikfabrik">
//  Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual
{
    using global::Umbraco.Core.Persistence;

    /// <summary>
    /// The <see cref="IndividualGuest" /> class.
    /// </summary>
    [TableName("uJetSocialIndividualGuest")]
    public sealed class IndividualGuest : Individual
    {
        private string _firstName;
        private string _lastName;
        private string _email;

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Column("FirstName")]
        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                AssertIsWritableClone();
                _firstName = value;
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Column("LastName")]
        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                AssertIsWritableClone();
                _lastName = value;
            }
        }

        /// <summary>
        /// Gets or sets the e-mail.
        /// </summary>
        /// <value>
        /// The e-mail.
        /// </value>
        [Column("Email")]
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                AssertIsWritableClone();
                _email = value;
            }
        }

        /// <summary>
        /// Gets a writable clone.
        /// </summary>
        /// <returns>A writable clone.</returns>
        public IndividualGuest CreateWritableClone()
        {
            return CreateWritableClone<IndividualGuest>();
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A writable clone of this instance.</returns>
        protected override DataTransferObject Clone()
        {
            var clone = new IndividualGuest
            {
                FirstName = _firstName,
                LastName = _lastName,
                Email = _email
            };

            return clone;
        }
    }
}
