using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.DB;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            List<User> oUsers = new List<User>();
            DataTable tb = cDatabase.GetUsers();
            foreach (DataRow row in tb.Rows)
            {
                oUsers.Add(new User()
                {
                    UserId = Convert.ToInt16(row["USER_ID"]),
                    FirstName = row["FIRST_NAME"].ToString(),
                    LastName = row["LAST_NAME"].ToString()
                });
            };

            return oUsers;
        }

        // POST api/values
        [HttpPost]
        public void PostUser([FromBody] User newUser)
        {
            cDatabase.SaveUser(newUser);
        }

    }
}
