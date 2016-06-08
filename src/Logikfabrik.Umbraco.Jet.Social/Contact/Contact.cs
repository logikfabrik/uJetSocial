// <copyright file="Contact.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Contact
{
    using System;
    using global::Umbraco.Core.Persistence;
    using Individual;

    /// <summary>
    /// The <see cref="Contact" /> class.
    /// </summary>
    [TableName("uJetSocialContact")]
    public class Contact : DataTransferObject
    {
        private int _fromMemberId;
        private int _toMemberId;

        /// <summary>
        /// Gets or sets the from member identifier.
        /// </summary>
        /// <value>
        /// The from member identifier.
        /// </value>
        [ForeignKey(typeof(IndividualMember), Name = "FK_uJetSocialContact_uJetSocialIndividualMember_Id_As_FromMemberId")]
        [Column("FromMemberId")]
        public int FromMemberId
        {
            get
            {
                return _fromMemberId;
            }

            set
            {
                AssertIsWritableClone();
                _fromMemberId = value;

                Updated = DateTime.Now;
            }
        }

        /// <summary>
        /// Gets or sets the to member identifier.
        /// </summary>
        /// <value>
        /// The to member identifier.
        /// </value>
        [ForeignKey(typeof(IndividualMember), Name = "FK_uJetSocialContact_uJetSocialIndividualMember_Id_As_ToMemberId")]
        [Column("ToMemberId")]
        public int ToMemberId
        {
            get
            {
                return _toMemberId;
            }

            set
            {
                AssertIsWritableClone();
                _toMemberId = value;

                Updated = DateTime.Now;
            }
        }

        /// <summary>
        /// Gets a writable clone.
        /// </summary>
        /// <returns>A writable clone.</returns>
        public Contact CreateWritableClone()
        {
            return CreateWritableClone<Contact>();
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A writable clone of this instance.
        /// </returns>
        protected override DataTransferObject Clone()
        {
            var clone = new Contact
            {
                FromMemberId = _fromMemberId,
                ToMemberId = _toMemberId
            };

            return clone;
        }
    }
}
