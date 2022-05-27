﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using absa.phonebook.api.Data.Dtos;
using absa.phonebook.api.Data.Models;
using absa.phonebook.api.Sevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace absa.phonebook.api.Controllers
{
    /// <summary>
    ///     This class provides api end points for phonebooks
    /// </summary>
    [ApiController]    
    public class PhonebookController : ControllerBase
    {
        /// <summary>
        ///     A <see cref="IPhonebookService"/> representing a service to be called.  
        /// </summary>
        private readonly IPhonebookService _phonebookService;

        /// <summary>
        ///     Initialise a new instance of the <see cref="PhonebookController"/> class.
        /// </summary>
        /// <param name="phonebookService">
        ///      A <see cref="IPhonebookService"/> representing the register service to be called.
        /// </param>
        public PhonebookController(IPhonebookService phonebookService)
        {
            _phonebookService = phonebookService;
        }


        /// <summary>
        ///     Retrieves then returns all of the phonebooks.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/phonebooks")]
        public async Task<IActionResult> GetPhonebooks()
        {
            var result = await _phonebookService.GetPhonebooks();
            return Ok(result);
        }


        [HttpPost]
        [Route("/phonebooks")]
        public async Task<IActionResult> CreatePhonebook(PhonebookDto dto)
        {
            var phonebook = new Phonebook() 
            {
                Name = dto.Name
            };

            var result = await _phonebookService.CreatePhonebook(phonebook);

            if (!result) return BadRequest();

            return NoContent();
        }
    }
}
