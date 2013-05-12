namespace RavenDB.ViewModels
{
    using System.Collections.Generic;

    using RavenDB.Models;

    /// <summary>
    /// Home page view model.
    /// </summary>
    public class HomePageViewModel
    {
        /// <summary>
        /// Gets or sets Users.
        /// </summary>
        public IEnumerable<UserModel> Users { get; set; }

        /// <summary>
        /// Gets or sets NewUser.
        /// </summary>
        public UserModel NewUser { get; set; }

        /// <summary>
        /// Gets or sets the search term.
        /// </summary>
        public string SearchTerm { get; set; }

        /// <summary>
        /// Gets or sets SearchResults.
        /// </summary>
        public IEnumerable<UserModel> SearchResults { get; set; }
    }
}