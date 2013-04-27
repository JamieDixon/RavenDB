using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RavenDB.Controllers
{
    using Raven.Client;

    using RavenDB.Data;
    using RavenDB.Models;

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
            using (var session = this.dataContext.OpenSession())
            {
                var vm = session.Query<UserModel>().Where(x => x.Age < 28);
                return View(vm);
            }
        }
    }
}
