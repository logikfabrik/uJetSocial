// <copyright file="DataTransferObject.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;
    using global::Umbraco.Core.Persistence;
    using global::Umbraco.Core.Persistence.DatabaseAnnotations;

    /// <summary>
    /// The <see cref="DataTransferObject" /> class.
    /// </summary>
    [PrimaryKey("Id", autoIncrement = false)]
    public abstract class DataTransferObject
    {
        private DateTime _created;
        private DateTime _updated;
        private int _status;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTransferObject" /> class.
        /// </summary>
        protected DataTransferObject()
        {
            _created = DateTime.UtcNow;
            _updated = DateTime.UtcNow;
            _status = 0;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [PrimaryKeyColumn(AutoIncrement = false)]
        [ForeignKey(typeof(Entity))]
        [Column("Id")]
        public int Id { get; internal set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        [Column("Created")]
        public DateTime Created
        {
            get
            {
                return _created;
            }

            set
            {
                AssertIsWritableClone();
                _created = value;
            }
        }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>
        /// The updated date.
        /// </value>
        [Column("Updated")]
        public DateTime Updated
        {
            get
            {
                return _updated;
            }

            set
            {
                AssertIsWritableClone();
                _updated = value;
            }
        }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [Column("Status")]
        public int Status
        {
            get
            {
                return _status;
            }

            set
            {
                AssertIsWritableClone();
                _status = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is read-only.
        /// </summary>
        /// <value>
        ///  <c>true</c> if this instance is read-only; otherwise, <c>false</c>.
        /// </value>
        [Ignore]
        public bool IsReadOnly { get; internal set; }

        /// <summary>
        /// Gets a writable clone.
        /// </summary>
        /// <typeparam name="T">The <see cref="DataTransferObject" /> type.</typeparam>
        /// <returns>A writable clone.</returns>
        protected T CreateWritableClone<T>()
            where T : DataTransferObject
        {
            return CreateWritableClone() as T;
        }

        /// <summary>
        /// Asserts that this instance is a writable clone.
        /// </summary>
        protected void AssertIsWritableClone()
        {
            DataTransferObjectValidator.ThrowIfReadOnly(IsReadOnly);
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A writable clone of this instance.</returns>
        protected abstract DataTransferObject Clone();

        /// <summary>
        /// Creates a writable clone of this instance.
        /// </summary>
        /// <returns>A writable clone of this instance.</returns>
        private DataTransferObject CreateWritableClone()
        {
            var clone = Clone();

            clone.Id = Id;
            clone.IsReadOnly = false;
            clone.Created = _created;
            clone.Updated = _updated;
            clone.Status = _status;

            return clone;
        }
    }
}
