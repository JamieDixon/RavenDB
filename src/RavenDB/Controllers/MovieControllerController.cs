namespace RavenDB.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using RavenDB.Data;
    using RavenDB.Models;

    public class MovieController : Controller
    {

        /// <summary>
        /// Data context.
        /// </summary>
        private readonly IDataContext dataContext;

        public MovieController(IDataContext dataContext)
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
                var movies = (from mov in session.Query<MovieModel>() orderby mov.Id ascending select mov).Take(20);
                return this.View(movies);
            }

        }

        /// <summary>
        /// </summary>
        /// <param name="assetId">
        /// The asset id.
        /// </param>
        /// <returns>
        /// </returns>
        public ActionResult View(int assetId)
        {
            return this.View();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpGet]
        public ActionResult Create(bool savedData = false)
        {
            ViewBag.Saved = savedData;
            return View();
        }

        [HttpPost]
        public ActionResult Create(MovieModel movie)
        {
            using (var session = this.dataContext.OpenSession())
            {
                for (var i = 0; i < 2000; i++)
                {
                    // Create 2000 sample movies.
                    var sampleMovie = new MovieModel
                        {
                            Title = "Hunger Games Version " + i,
                            Synopsis = "This is the " + i + " movie",
                            Classification =
                                new ClassificationModel { ClassificationType = ClassificationType.None, Name = "None" },
                            Cast =
                                new List<string> { "James Robson", "Robbert George", "Ashley Mills", "Geoff Buckley", "Sharon Davies" },
                            Crew =
                                new List<string> { "Steve Soundman", "Cane Cameraman", "Richard Rodman", "Darth Vadar" },
                            ThumbnailUrl =
                                "http://www.hollywoodreporter.com/sites/default/files/2012/11/hunger_games_video_thumbnail_648_x_365_21.jpg",
                            BannerUrl =
                                "http://www.hollywoodreporter.com/sites/default/files/imagecache/thumbnail_570x321/2012/02/hunger_games_banner.jpg",
                            TotalLength = new TimeSpan(2, 20, 0),
                            VideoUrl = "http://SomeVideoUrl.mp4"
                        };
                    session.Store(sampleMovie);
                }

                session.SaveChanges();
            }

            return this.RedirectToAction("Create", new { savedData = true });
        }

    }
}
