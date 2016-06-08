// <copyright file="GroupMembership.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group
{
    using System;
    using global::Umbraco.Core.Persistence;
    using Individual;

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
        [ForeignKey(typeof(Group), Name = "FK_uJetSocialGroupMembership_uJetSocialGroup_Id_As_GroupId")]
        [Column("GroupId")]
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

                Updated = DateTime.Now;
            }
        }

        /// <summary>
        /// Gets or sets the member identifier.
        /// </summary>
        /// <value>
        /// The member identifier.
        /// </value>
        [ForeignKey(typeof(IndividualMember), Name = "FK_uJetSocialGroupMembership_uJetSocialIndividualMember_Id_As_MemberId")]
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

                Updated = DateTime.Now;
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
