
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       
         [HttpGet]
        public ActionResult<List<UserM>> GetUsers()
        {
            var UsersDB = UserManager.UserList();
            var Result = new List<UserM>();
            foreach (var userDB in UsersDB)
            {
                Result.Add(new UserM()
                {
                    User_Id = userDB.Id,
                    FirstName = userDB.FirstName,
                    LastName = userDB.LastName
                });
            }
            return Result;

        }

        [HttpGet("{id}")]
        public ActionResult<UserM> GetUserByID(int id)
        {
            var userDB = UserManager.UserById(id);
            var Result = new UserM() {
                User_Id = userDB.Id,
                FirstName = userDB.FirstName,
                LastName = userDB.LastName
            };

            return Result;
        }

        [HttpGet("{id}")]
        public void DelUserByID(int id)
        {
            UserManager.DelUserById(id);
        }

        [HttpPost]
        public void PostUser([FromBody] User newUser)
        {
           UserManager.AddUser(newUser);
        }

        [HttpPost]
        public void UpdateUser([FromBody] User newUser)
        {
            UserManager.UpdateUser(newUser);
        }

    }
}