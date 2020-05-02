using QandA_lesson1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QandA_lesson1.DataStore
{
    public class DbHandler
    {
        public List<User> GetUsers()
        {
            return new List<User>()
            {
                new User{ Username = "john", Password= "john"},
                new User { Username = "alex", Password = "admin"}
            };
        }
    }
}
