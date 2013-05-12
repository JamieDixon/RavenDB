namespace RavenDB.Models
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    /// <summary>
    /// Reprisents a user.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets Tags.
        /// </summary>
        public IEnumerable<string> Tags { get; set; }
    }
}