using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IUserService oUserService;
        public ValuesController(IUserService userService)
        {
            this.oUserService = userService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return this.oUserService.getFullName();
        }

      
    }
}
