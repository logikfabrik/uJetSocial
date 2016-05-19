// <copyright file="IndividualMember.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual
{
    using global::Umbraco.Core.Persistence;

    /// <summary>
    /// The <see cref="IndividualMember" /> class.
    /// </summary>
    [TableName("uJetSocialIndividualMember")]
    public class IndividualMember : Individual
    {
        private int _memberId;

        /// <summary>
        /// Gets or sets the member identifier.
        /// </summary>
        /// <value>
        /// The member identifier.
        /// </value>
        [ForeignKey("Umbraco.Core.Models.Rdbms.NodeDto, Umbraco.Core")]
        [ForeignKey("Umbraco.Core.Models.Rdbms.ContentDto, Umbraco.Core", Column = "nodeId")]
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
        public IndividualMember CreateWritableClone()
        {
            return CreateWritableClone<IndividualMember>();
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A writable clone of this instance.</returns>
        protected override DataTransferObject Clone()
        {
            var clone = new IndividualMember
            {
                MemberId = _memberId
            };

            return clone;
        }
    }
}
