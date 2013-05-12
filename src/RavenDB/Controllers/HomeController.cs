using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RavenDB.Controllers
{
    using System.Data.Linq.SqlClient;
    using RavenDB.Data;
    using RavenDB.Models;
    using RavenDB.ViewModels;

    public class HomeController : Controller
    {
        /// <summary>
        /// Data context.
        /// </summary>
        private readonly IDataContext dataContext;

        public HomeController(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public ActionResult Index()
        {
            var vm = new HomePageViewModel
            {
                Users = this.GetAllUsers(),
                NewUser = new UserModel(),
                SearchResults = Enumerable.Empty<UserModel>()
            };

            return this.View(vm);
        }

        [HttpPost]
        public ActionResult Index(HomePageViewModel homePageViewModel)
        {
            using (var session = this.dataContext.OpenSession())
            {
                session.Store(homePageViewModel.NewUser);

                session.SaveChanges();
            }

            return this.RedirectToAction("Index");
        }

        public ActionResult Search(string searchTerm)
        {
            IEnumerable<UserModel> users;

            int age;

            var isAgeSearch = int.TryParse(searchTerm, out age);

            using (var session = this.dataContext.OpenSession())
            {
                users = from u in session.Query<UserModel>()
                        where u.Name.StartsWith(searchTerm)
                        || u.Name.EndsWith(searchTerm)
                        || u.Tags.Any(x => x == searchTerm)
                        || u.Age == age
                        select u;

            }

            var vm = new HomePageViewModel
                {
                    Users = this.GetAllUsers(),
                    SearchResults = users
                };

            return this.View("Index", vm);
        }

        private IEnumerable<UserModel> GetAllUsers()
        {
            using (var session = this.dataContext.OpenSession())
            {
                return session.Query<UserModel>();
            }
        }
    }
}
