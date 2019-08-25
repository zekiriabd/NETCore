using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class UserM
    {
            public int User_Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public string Name {
                get { return FirstName + " " + LastName; }
            }
    }
}
