using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            oUsers.Add(new User(){ UserId= 1 , FirstName="Zekiri1", LastName="Abdelali1"});
            oUsers.Add(new User(){ UserId= 2 , FirstName="Zekiri2", LastName="Abdelali2"});
            oUsers.Add(new User(){ UserId= 3 , FirstName="Zekiri3", LastName="Abdelali3"});
            return  oUsers;
        }

        // GET api/values/5
        
        // POST api/values
        [HttpPost]
        public void PostUser([FromBody] User newUser)
        {
            Console.WriteLine(newUser.ToString());
         
        }

       
    }
}
