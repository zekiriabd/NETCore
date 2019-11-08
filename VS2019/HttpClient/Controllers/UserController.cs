using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private UserDataAccess userDataAccess = new UserDataAccess();

        private readonly HttpClient hClient = new HttpClient();
        
        private readonly string URL = "http://localhost:8080/api/";

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            string action = "user/getUsers/";
            string json = await hClient.GetStringAsync(URL + action);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            return users;
        }

        [HttpPost]
        public async Task PostUser([FromBody] User newUser)
        {
            string action = "user/postUser/";
            string json = JsonConvert.SerializeObject(newUser);
            var content = new StringContent(json, Encoding.Default, "application/json");
            await hClient.PostAsync(URL + action, content);
        }


        /*
        [HttpGet("{id}")]
        public ActionResult<User> GetUserByID(int id)
        {
            return userDataAccess.Users.FirstOrDefault(u => u.Id == id);
        }

        
        [HttpGet("{id}")]
        public void DelUserByID(int id)
        {
            var user = userDataAccess.Users.Find(id);
            userDataAccess.Users.Remove(user);
            userDataAccess.SaveChanges();
        }

        [HttpPost]
        public void UpdateUser([FromBody] User newUser)
        {
            userDataAccess.Users.Update(newUser);
            userDataAccess.SaveChanges();
        }*/
        
    }
}
