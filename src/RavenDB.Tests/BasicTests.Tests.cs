using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RavenDB.Tests
{
    using Raven.Abstractions.Indexing;
    using Raven.Client.Document;
    using Raven.Client.Indexes;

    using RavenDB.Models;

    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void CreateSampleData()
        {
            var people = new List<UserModel>
                {
                    new UserModel
                        {
                            Name = "Jamie Dixon",
                            Age = 28,
                            Tags =
                                new List<string>
                                    {
                                       "ASPNET",
                                       "CSharp",
                                       "RavenDb"
                                    }
                        },
                        new UserModel
                        {
                            Name = "Rob Smithson",
                            Age = 25,
                            Tags =
                                new List<string>
                                    {
                                       "ASPNET",
                                       "CSharp",
                                       "RavenDb"
                                    }
                        },
                        new UserModel
                        {
                            Name = "Dorris Day",
                            Age = 19,
                            Tags =
                                new List<string>
                                    {
                                       "ASPNET",
                                       "CSharp",
                                       "RavenDb"
                                    }
                        }
                };

            var store = new DocumentStore()
                {
                    Url = "http://jamie-vaio:8080/",
                    DefaultDatabase = "Demo",

                };

            store.Initialize();

            using (var session = store.OpenSession())
            {

                foreach (var person in people)
                {
                    session.Store(person);
                }

                session.SaveChanges();

                var jamie = session.Query<UserModel>().Where(x => x.Name == "Jamie Dixon").First();

                Assert.AreEqual(28, jamie.Age);


            }
        }

    }
}
