namespace RavenDB
{
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Raven.Client.Document;
    using Raven.Client.Indexes;
    using Ninject;
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    /// <summary>
    /// Global.asax.cs
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// The document store.
        /// </summary>
        public static DocumentStore Store;

        /// <summary>
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Store = new DocumentStore
            {
                Url = "http://jamie-vaio:8080/",
                DefaultDatabase = "Demo",
            };

            Store.Initialize();

            IndexCreation.CreateIndexes(typeof(MvcApplication).Assembly, Store);
        }

        protected void Application_End()
        {
            Store.Dispose();
        }
    }
}