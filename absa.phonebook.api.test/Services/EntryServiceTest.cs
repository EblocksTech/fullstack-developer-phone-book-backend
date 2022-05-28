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
    ///     Provide unit test to test <see cref="EntryService"/> class.
    /// </summary>
    public class EntryServiceTest
    {
        /// <summary>
        ///      A <see cref="EntryService"/>  representing the subject under test.
        /// </summary>
        private readonly EntryService _service;

        /// <summary>
        ///     A <see cref="Mock"/> implementation of <see cref="IEntryStore"/> representing the store to be mocked.         
        /// </summary>
        private readonly Mock<IEntryStore> _entryStoreMock;

        /// <summary>
        ///     A <see cref="Mock"/> implementation of <see cref="IPhonebookStore"/> representing the store to be mocked.         
        /// </summary>
        private readonly Mock<IPhonebookStore> _phonebookStoreMock;

        /// <summary>
        ///     Initialise an  instance of the <see cref="EntryServiceTest"/>  class.
        /// </summary>
        /// 
        public EntryServiceTest()
        {
            _entryStoreMock = new Mock<IEntryStore>();
            _phonebookStoreMock = new Mock<IPhonebookStore>();

            _service = new EntryService(_entryStoreMock.Object, _phonebookStoreMock.Object);
        }

        /// <summary>
        ///     Tests that all entries are returned.
        /// </summary>        
        [Fact]
        public async Task GetAllEntries_Should_Get_All_Entries()
        {
            // Arrannge
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

            _entryStoreMock.Setup(x => x.GetAllEntries()).ReturnsAsync(list);

            // Act 
            var result = await _service.GetAllEntries();
            var count = result.Count;

            // Assert
            Assert.Equal(3, count);
        }

        /// <summary>
        ///     Tests that an entry was created successfully.
        /// </summary>        
        [Fact]
        public async Task CreateEntry_Should_Create_Entry_Successfully()
        {
            // Arrange
            var phonebookId = Guid.NewGuid();
            var entry = new Entry()
            {
                Id = Guid.NewGuid(),
                Name = "Mr D",
                Number = "011-342-1720",
                PhonebookId = phonebookId
            };

            var phonebook = new Phonebook() 
            {
                Name = "General",
                Id = phonebookId
            };

            _entryStoreMock.Setup(x => x.GetEntryByNumber("011-342-1711")).ReturnsAsync(() => null);
            _entryStoreMock.Setup(x => x.CreateEntry(entry)).ReturnsAsync(true);
            _phonebookStoreMock.Setup(x => x.GetPhonebookById(phonebookId)).ReturnsAsync(phonebook);

            // Act
            var result = await _service.CreateEntry(entry);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that a <see cref="Entry"/> cannot be created when the number already exists.
        /// </summary>        
        [Fact]
        public async Task CreateEntry_Should_Return_BadRequest_When_Number_Already_Exists()
        {
            // Arrange
            var entry = new Entry()
            {
                Id = Guid.NewGuid(),
                Name = "Mr D",
                Number = "011-342-1720",
                PhonebookId = Guid.NewGuid()
            };

            _entryStoreMock.Setup(x => x.GetEntryByNumber("011-342-1720")).ReturnsAsync(() => entry);

            // Act
            var result = await _service.CreateEntry(entry);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///      Tests that a <see cref="Entry"/> cannot be created when the <see cref="Phonebook"/> does not exist.
        /// </summary>        
        [Fact]
        public async Task CreateEntry_Should_return_BadRequest_When_Phonebook_Does_Not_Exist()
        {
            // Arrange
            var entry = new Entry()
            {
                Id = Guid.NewGuid(),
                Name = "Mr D",
                Number = "011-342-1720",
                PhonebookId = Guid.NewGuid()
            };

            _phonebookStoreMock.Setup(x => x.GetPhonebookById(entry.Id)).ReturnsAsync(() => null);

            // Act

            var result = await _service.CreateEntry(entry);

            // Assert
            Assert.False(result);
        }
    }
}
