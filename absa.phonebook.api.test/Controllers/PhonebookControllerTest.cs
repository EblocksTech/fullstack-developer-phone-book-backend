using absa.phonebook.api.Controllers;
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
        ///     <see cref="PhonebookController"/> representing the subject under test. 
        /// </summary>
        private readonly PhonebookController _controller;

        /// <summary>
        ///      A <see cref="Mock"/> implementation of <see cref="IPhonebookService"/>
        /// </summary>
        private readonly Mock<IPhonebookService> _phonebookServiceMock = new Mock<IPhonebookService>();
        
        /// <summary>
        ///     Initialise an  instance of the <see cref="PhonebookControllerTest"/> class.
        /// </summary>
        public PhonebookControllerTest()
        {
            _controller = new PhonebookController(_phonebookServiceMock.Object);
        }

        /// <summary>
        ///     The following test checks if a list of phonebooks are returned succesfully.
        /// </summary>
        [Fact]
        public async Task PhonebookController_Return_List_Of_Phonebooks()
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
    }
}
