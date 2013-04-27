using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RavenDB.Data
{
    using Raven.Client;

    public class DataContext : IDataContext
    {
        public IDocumentSession OpenSession()
        {
            return MvcApplication.Store.OpenSession();
        }
    }
}