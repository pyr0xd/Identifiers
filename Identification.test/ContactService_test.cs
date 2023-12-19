using Xunit;
using Moq;
using ContactApp.Interfaces;
using ContactApp.Models;
using ContactApp.Services;
using System.Collections.Generic;
using System.Linq;
using Identification.Interface;

namespace ContactApp.Tests
{
    public class ContactServiceTests
    {
        private readonly Mock<IContactStorage> _mockStorage;
        private readonly ContactService _contactService;
        private List<Contact> _contacts;

        public ContactServiceTests()
        {
            // Arrange for all tests
            _contacts = new List<Contact>();
            _mockStorage = new Mock<IContactStorage>();

            _mockStorage.Setup(s => s.LoadContacts()).Returns(_contacts);
            _mockStorage.Setup(s => s.SaveContacts(It.IsAny<IEnumerable<Contact>>()))
                        .Callback<IEnumerable<Contact>>(contacts => _contacts = contacts.ToList());

            _contactService = new ContactService(_mockStorage.Object);
        }

        [Fact]
        public void AddContact_ShouldAddContact()
        {
            // Arrange
            var contact = new Contact { Email = "test@example.com" };

            // Act
            _contactService.AddContact(contact);
            

            // Assert
            Assert.Contains(contact, _contacts);// This will pass if the contact was added successfully, fail otherwise
            
        }

        [Fact]
        public void DeleteContact_ShouldRemoveContact()
        {
            // Arrange
            var contact = new Contact { Email = "test@example.com" };
            _contacts.Add(contact);

            // Act
            _contactService.DeleteContact(contact.Email);

            // Assert
            var result = !_contacts.Contains(contact);
           
        }

        [Fact]
        public void UpdateContact_ShouldUpdateContactDetails()
        {
            // Arrange
            var contact = new Contact { Email = "test@example.com", FirstName = "OldName" };
            _contacts.Add(contact);

            var updatedContact = new Contact { Email = "test@example.com", FirstName = "NewName" };

            // Act
            _contactService.UpdateContact(updatedContact);

            // Assert
            var contactInList = _contacts.FirstOrDefault(c => c.Email == "test@example.com");
            var result = contactInList != null && contactInList.FirstName == "NewName";
            
        }
    }
}
