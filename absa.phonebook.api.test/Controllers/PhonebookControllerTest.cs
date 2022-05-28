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
    ///     Provides tests for the PhonebookController.
    /// </summary>
    public class PhonebookControllerTest
    {
        /// <summary>
        ///     A <see cref="PhonebookController"/> representing the subject under test. 
        /// </summary>
        private readonly PhonebookController _controller;

        /// <summary>
        ///      A <see cref="Mock"/> implementation of <see cref="IPhonebookService"/>
        /// </summary>
        private readonly Mock<IPhonebookService> _phonebookServiceMock;
        
        /// <summary>
        ///     Initialise an  instance of the <see cref="PhonebookControllerTest"/> class.
        /// </summary>
        public PhonebookControllerTest()
        {
            _phonebookServiceMock = new Mock<IPhonebookService>();
            _controller = new PhonebookController(_phonebookServiceMock.Object);
        }

        /// <summary>
        ///     The following test checks if a list of phonebooks are returned succesfully.
        /// </summary>
        [Fact]
        public async Task GetPhonebooks_Should_Return_List_Of_Phonebooks()
        {
            // Arrange 
            var list = new List<Phonebook>() 
            {
                new Phonebook()
                {
                    Id = Guid.NewGuid(),
                    Name = "General",
                },
                new Phonebook()
                {
                    Id = Guid.NewGuid(),
                    Name = "Family",
                },
                new Phonebook()
                {
                    Id = Guid.NewGuid(),
                    Name = "Bussiness",
                }
            };

            _phonebookServiceMock.Setup(x => x.GetPhonebooks()).ReturnsAsync(list);

            // Act

            var result = await _controller.GetPhonebooks() as OkObjectResult;
            var value = (List<Phonebook>) result.Value;

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(3, value.Count);
        }


        /// <summary>
        ///     The following test checks if a phonebooks was created successfully.
        /// </summary>        
        [Fact]
        public async Task CreatePhonebook_Should_Create_New_Phonebook()
        {
            // Arrange
            var dto = new PhonebookDto()
            {
                Name = "General"
            };

            _phonebookServiceMock.Setup(x => x.CreatePhonebook(It.IsAny<Phonebook>())).ReturnsAsync(true);

            // Act 
            var result = await _controller.CreatePhonebook(dto) as NoContentResult;

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        /// <summary>
        ///      The following test checks if a phonebooks was created unsuccessfully.
        /// </summary>        
        [Fact]
        public async Task CreatePhonebook_Should_Fail_When_Create_Was_Unsuccessful()
        {
            // Arrange
            _phonebookServiceMock.Setup(x => x.CreatePhonebook(It.IsAny<Phonebook>())).ReturnsAsync(false);

            // Act
            var result = await _controller.CreatePhonebook(new PhonebookDto()) as BadRequestResult;

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
