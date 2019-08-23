using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ORM;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET api/values
        private  DBUserList dbUserList = new DBUserList();

        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            List<DBUser> dbusers = dbUserList.GetUsers();
            List<User> oUsers = new List<User>();
            foreach (DBUser dbuser in dbusers)
            {
                oUsers.Add(new User() { FirstName = dbuser.FirstName, LastName = dbuser.LastName });
            }

            return oUsers;
        }

        // POST api/values
        [HttpPost]
        public void PostUser([FromBody] User newUser)
        {
            DBUser dbNewUser = new DBUser() {
                FirstName = newUser.FirstName, LastName = newUser.LastName
            };

            dbUserList.SaveUser(dbNewUser);
        }

    }
}
