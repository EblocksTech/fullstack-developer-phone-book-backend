using absa.phonebook.api.Data.Dtos;
using absa.phonebook.api.Data.Models;
using absa.phonebook.api.Sevices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace absa.phonebook.api.Controllers
{
    /// <summary>
    ///      This class provides api end points for entries.
    /// </summary>
    [ApiController]
    public class EntryController : ControllerBase
    {
        /// <summary>
        ///      A <see cref="IEntryService"/> representing a service to be called.  
        /// </summary>
        private readonly IEntryService _entryService;

        /// <summary>
        ///     Initialise a new instance of the <see cref="EntryController"/> class.  
        /// </summary>
        /// <param name="entryService">
        ///      A <see cref="IEntryService"/> representing the service injected into controller.
        /// </param>
        public EntryController(IEntryService entryService)
        {
            _entryService = entryService;
        }

        /// <summary>
        ///      Retrieves then returns all of the entries.
        /// </summary>
        /// <returns>
        ///      A <see cref="IActionResult"/> representing the result of the api call.
        /// </returns>
        [HttpGet]
        [Route("/entries")]
        public async Task<IActionResult> GetAllEntries()
        {
            var result = await _entryService.GetAllEntries();

            return Ok(result);
        }

        /// <summary>
        ///     Creates a new entry in the system.        
        /// </summary>
        /// <param name="dto">
        ///      A <see cref="EntryDto"/> representing the phonebook to be created.
        /// </param>
        /// <returns>
        ///      A <see cref="IActionResult"/> representing the result of the api call.
        /// </returns>
        [HttpPost]
        [Route("/entries")]
        public async Task<IActionResult> CreateEntry(EntryDto dto)
        {
            var entry = new Entry() 
            {
                PhonebookId = dto.PhonebookId,
                Name = dto.Name,
                Number = dto.Number
            };

            var result = await _entryService.CreateEntry(entry);

            if (!result) return BadRequest();

            return NoContent();
        }
    }
}
