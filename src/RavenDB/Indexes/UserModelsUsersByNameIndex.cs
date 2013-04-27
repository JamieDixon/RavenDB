namespace RavenDB.Indexes
{
    using System.Linq;
    using Raven.Client.Indexes;

    using RavenDB.Models;

    /// <summary>
    /// An index for querying user models by name.
    /// </summary>
    public class UserModelsUsers : AbstractIndexCreationTask<UserModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserModelsUsers"/> class.
        /// </summary>
        public UserModelsUsers()
        {
            Map = users => from user in users select new { user.Name, user.Age };
        }

        /// <summary>
        /// Gets IndexName.
        /// </summary>
        public override string IndexName
        {
            get
            {
                return "UserModels/UserTestDemo";
            }
        }
    }
}