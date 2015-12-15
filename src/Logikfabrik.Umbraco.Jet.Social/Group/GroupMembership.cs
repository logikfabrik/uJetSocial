// <copyright file="GroupMembership.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group
{
    using global::Umbraco.Core.Persistence;
    using Member;

    /// <summary>
    /// The <see cref="GroupMembership" /> class.
    /// </summary>
    [TableName("uJetSocialGroupMembership")]
    public class GroupMembership : DataTransferObject
    {
        private int _groupId;
        private int _memberId;

        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>
        /// The group identifier.
        /// </value>
        [ForeignKey(typeof(Member), Name = "FK_uJetSocialGroupMembership_uJetSocialGroup_Id_As_GroupId")]
        [Column("MemberId")]
        public int GroupId
        {
            get
            {
                return _groupId;
            }

            set
            {
                AssertIsWritableClone();
                _groupId = value;
            }
        }

        /// <summary>
        /// Gets or sets the member identifier.
        /// </summary>
        /// <value>
        /// The member identifier.
        /// </value>
        [ForeignKey(typeof(Member), Name = "FK_uJetSocialGroupMembership_uJetSocialMember_Id_As_MemberId")]
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
        public GroupMembership CreateWritableClone()
        {
            return CreateWritableClone<GroupMembership>();
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A writable clone of this instance.</returns>
        protected override DataTransferObject Clone()
        {
            var clone = new GroupMembership
            {
                GroupId = _groupId,
                MemberId = _memberId
            };

            return clone;
        }
    }
}
