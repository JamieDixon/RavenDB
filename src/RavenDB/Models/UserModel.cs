using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RavenDB.Models
{
    public class UserModel
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}