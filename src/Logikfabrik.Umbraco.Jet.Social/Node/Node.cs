// <copyright file="Node.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Node
{
    using global::Umbraco.Core.Persistence;
    using global::Umbraco.Core.Persistence.DatabaseAnnotations;

    /// <summary>
    /// The <see cref="Node" /> class.
    /// </summary>
    [TableName("uJetSocialNode")]
    public class Node : DataTransferObject
    {
        private int _nodeId;

        //[ForeignKey(typeof(Social.Node), Name = "EntityId")]
        [Column("NodeId")]
        public int NodeId
        {
            get
            {
                return _nodeId;
            }

            set
            {
                AssertIsWritableClone();
                _nodeId = value;
            }
        }

        protected override DataTransferObject Clone()
        {
            throw new System.NotImplementedException();
        }
    }
}
