using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RavenDB.Models
{
    public class ClassificationModel
    {
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets ClassificationType.
        /// </summary>
        public ClassificationType ClassificationType { get; set; }

    }
}