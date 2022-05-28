using absa.phonebook.api.Data.Models;
using absa.phonebook.api.Sevices;
using absa.phonebook.api.Stores;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace absa.phonebook.api.test.Services
{
    /// <summary>
    ///     Provide unit test to test <see cref="PhonebookService"/> class.
    /// </summary>
    public class PhonebookServiceTest
    {
        /// <summary>
        ///      A <see cref="IPhonebookService"/>  representing the subject under test.
        /// </summary>
        private readonly IPhonebookService _service;

        /// <summary>
        ///     A <see cref="Mock"/> implementation of <see cref="IPhonebookStore"/> representing the store to be mocked.         
        /// </summary>
        private readonly Mock<IPhonebookStore> _store;

        /// <summary>
        ///     Initialise an  instance of the <see cref="PhonebookServiceTest"/>  class.
        /// </summary>
        public PhonebookServiceTest()
        {
            _store = new Mock<IPhonebookStore>();
            _service = new PhonebookService(_store.Object);
        }

        /// <summary>
        ///      Tests that all phonebooks are returned.         
        /// </summary>        
        [Fact]
        public async Task GetPhonebooks_Should_Get_All_Phonebooks()
        {
            // Arrange
            var list = new List<Phonebook>()
            {
                new Phonebook()
                {
                    Name = "General",
                    Id = Guid.NewGuid()
                },
                new Phonebook()
                {
                    Name = "Family",
                    Id = Guid.NewGuid()
                },
            };

            _store.Setup(x => x.GetPhonebooks()).ReturnsAsync(list);

            // Act
            var result = await _service.GetPhonebooks();

            // Assert
            Assert.Equal(2, result.Count);
        }

        /// <summary>
        ///     Tests that a <see cref="Phonebook"/> is created.
        /// </summary>        
        [Fact]
        public async Task CreatePhonebook_Should_Create_Phonebook()
        {
            // Arrange
            var phonebook = new Phonebook() 
            {
                Name = "General"
            };

            _store.Setup(x => x.CreatePhonebook(phonebook)).ReturnsAsync(true);
            _store.Setup(x => x.GetPhonebooks()).ReturnsAsync(new List<Phonebook>());

            // Act
            var result = await _service.CreatePhonebook(phonebook);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that a <see cref="Phonebook"/> with a name that already exists cannot be created.
        /// </summary>        
        [Fact]
        public async Task CreatePhonebook_Should_Fail_When_Phonebook_With_Same_Name_Already_Exists()
        {
            // Arrange
            var phonebook = new Phonebook()
            {
                Name = "General"
            };

            var list = new List<Phonebook>() {};
            list.Add(phonebook);

            _store.Setup(x => x.GetPhonebooks()).ReturnsAsync(list);

            // Act
            var result = await _service.CreatePhonebook(phonebook);

            // Assert
            Assert.False(result);
        }
    }
}
