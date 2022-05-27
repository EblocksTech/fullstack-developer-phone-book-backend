using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace absa.phonebook.api.Controllers
{
    [ApiController]    
    public class PhonebookController : ControllerBase
    {        
        public PhonebookController()
        {
        }

        [HttpGet]
        [Route("/phonebooks")]
        public IActionResult Get()
        {
            return null;
        }
    }
}
