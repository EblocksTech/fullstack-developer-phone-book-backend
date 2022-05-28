using absa.phonebook.api.Controllers;
using absa.phonebook.api.Data.Dtos;
using absa.phonebook.api.Data.Models;
using absa.phonebook.api.Sevices;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace absa.phonebook.api.test.Controllers
{
    /// <summary>
    ///     Provides tests for the EntryController.
    /// </summary>
    public class EntryControllerTest
    {
        /// <summary>
        ///     A <see cref="EntryController"/> representing the subject under test. 
        /// </summary>
        private readonly EntryController _controller;

        /// <summary>
        ///      A <see cref="Mock"/> implementation of <see cref="IEntryService"/>
        /// </summary>
        private readonly Mock<IEntryService> _entryServiceMock;

        /// <summary>
        ///     Initialise an  instance of the <see cref="EntryControllerTest"/> class.
        /// </summary>
        public EntryControllerTest()
        {
            _entryServiceMock = new Mock<IEntryService>();
            _controller = new EntryController(_entryServiceMock.Object);
        }

        /// <summary>
        ///     The following test checks if a list of entries are returned succesfully.
        /// </summary>        
        [Fact]
        public async Task GetAllEntries_Shoul_Return_List_Of_Entries()
        {
            // Arrange 
            var generalId = Guid.NewGuid();

            var list = new List<Entry>()
            {
                new Entry()
                {
                    Id = Guid.NewGuid(),
                    Name = "Mom",
                    Number = "081-704-6758",
                    PhonebookId = generalId
                },

                new Entry()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dad",
                    Number = "081-365-8532",
                    PhonebookId = generalId
                },

                new Entry()
                {
                    Id = Guid.NewGuid(),
                    Name = "Mr D",
                    Number = "011-342-1720",
                    PhonebookId = generalId
                }
            };

            _entryServiceMock.Setup(x => x.GetAllEntries()).ReturnsAsync(list);

            // Act

            var result = await _controller.GetAllEntries() as OkObjectResult;
            var value = (List<Entry>)result.Value;

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(3, value.Count);
        }


        /// <summary>
        ///      The following test checks if a entry was created successfully.
        /// </summary>        
        [Fact]
        public async Task CreateEntry_Should_Create_Entry()
        {
            // Arrange
            _entryServiceMock.Setup(x => x.CreateEntry(It.IsAny<Entry>())).ReturnsAsync(true);
            var dto = new EntryDto() 
            {
                Name = "Uncle Sam",
                Number = "079-309-7768",
                PhonebookId = Guid.NewGuid()
            };
            // Act
            var result = await _controller.CreateEntry(dto) as NoContentResult;

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        /// <summary>
        ///     The following test checks if a entry creation was unsuccessful.
        /// </summary>        
        [Fact]
        public async Task CreateEntry_Should_Return_BadRequest_When_Operation_Failed()
        {
            // Arrange
            _entryServiceMock.Setup(x => x.CreateEntry(It.IsAny<Entry>())).ReturnsAsync(false);
            var dto = new EntryDto()
            {
                Name = "Uncle Sam",
                Number = "079-309-7768",
                PhonebookId = Guid.NewGuid()
            };
            // Act
            var result = await _controller.CreateEntry(dto) as BadRequestResult;

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
