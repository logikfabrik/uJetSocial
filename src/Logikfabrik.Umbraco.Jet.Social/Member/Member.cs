// <copyright file="Member.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Member
{
    using global::Umbraco.Core.Persistence;

    /// <summary>
    /// The <see cref="Member" /> class.
    /// </summary>
    [TableName("uJetSocialMember")]
    public class Member : DataTransferObject
    {
        private int _memberId;

        /// <summary>
        /// Gets or sets the member identifier.
        /// </summary>
        /// <value>
        /// The member identifier.
        /// </value>
        [ForeignKey("Umbraco.Core.Models.Rdbms.MemberDto,Umbraco.Core", Name = "FK_uJetSocialMember_MemberId")]
        [Column("MemberId")]
        public int MemberId
        {
            get
            {
                return _memberId;
            }

            set
            {
                AssertIsWritableClone();
                _memberId = value;
            }
        }

        /// <summary>
        /// Gets a writable clone.
        /// </summary>
        /// <returns>A writable clone.</returns>
        public Member CreateWritableClone()
        {
            return CreateWritableClone<Member>();
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A writable clone of this instance.
        /// </returns>
        protected override DataTransferObject Clone()
        {
            var clone = new Member
            {
                MemberId = _memberId
            };

            return clone;
        }
    }
}
