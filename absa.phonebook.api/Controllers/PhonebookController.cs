using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using absa.phonebook.api.Sevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace absa.phonebook.api.Controllers
{
    [ApiController]    
    public class PhonebookController : ControllerBase
    {
        private readonly IPhonebookService _phonebookService;

        public PhonebookController(IPhonebookService phonebookService)
        {
            _phonebookService = phonebookService;
        }


        [HttpGet]
        [Route("/phonebooks")]
        public async Task<IActionResult> GetPhonebooks()
        {
            var result = await _phonebookService.GetPhonebooks();
            return Ok(result);
        }
    }
}
