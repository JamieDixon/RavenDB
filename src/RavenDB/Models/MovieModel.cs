using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RavenDB.Models
{
    using System.Text;

    /// <summary>
    /// </summary>
    public class MovieModel
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public string Id
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Synopsis.
        /// </summary>
        public string Synopsis { get; set; }

        /// <summary>
        /// Gets or sets ThumbnailUrl.
        /// </summary>
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// Gets or sets BannerUrl.
        /// </summary>
        public string BannerUrl { get; set; }

        /// <summary>
        /// Gets or sets VideoUrl.
        /// </summary>
        public string VideoUrl { get; set; }

        /// <summary>
        /// Gets or sets Cast.
        /// </summary>
        public IList<string> Cast { get; set; }

        /// <summary>
        /// Gets or sets Crew.
        /// </summary>
        public IList<string> Crew { get; set; }

        /// <summary>
        /// Gets or sets TotalLength.
        /// </summary>
        public TimeSpan TotalLength { get; set; }

        /// <summary>
        /// Gets or sets Classification.
        /// </summary>
        public ClassificationModel Classification { get; set; }
    }
}