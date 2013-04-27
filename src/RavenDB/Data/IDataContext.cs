// -----------------------------------------------------------------------
// <copyright file="IDataContext.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace RavenDB.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Raven.Client;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IDataContext
    {
        /// <summary>
        /// Opens a session to the data store.
        /// </summary>
        /// <returns>
        /// Document Session.
        /// </returns>
        IDocumentSession OpenSession();
    }
}
