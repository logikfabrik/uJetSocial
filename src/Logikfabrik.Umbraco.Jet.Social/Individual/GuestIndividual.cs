// <copyright file="GuestIndividual.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual
{
    /// <summary>
    /// Represents a guest individual.
    /// </summary>
    public class GuestIndividual : Individual
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
        /// The email.
        /// </value>
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
        /// Gets a clone of the current entity.
        /// </summary>
        /// <returns>A clone of the current entity.</returns>
        protected override Entity Clone()
        {
            var clone = new GuestIndividual
            {
                FirstName = _firstName,
                LastName = _lastName,
                Email = _email
            };

            return clone;
        }
    }
}
