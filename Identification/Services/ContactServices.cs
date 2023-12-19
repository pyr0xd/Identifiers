using ContactApp.Interfaces;
using ContactApp.Models;
using Identification.Interface;
using System.Collections.Generic;
using System.Linq;

namespace ContactApp.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactStorage _storage;
        private readonly List<Contact> _contacts;

        public ContactService(IContactStorage storage)
        {
            _storage = storage;
            _contacts = _storage.LoadContacts().ToList();
        }

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
            _storage.SaveContacts(_contacts);
        }

        public void DeleteContact(string email)
        {
            var contact = _contacts.FirstOrDefault(c => c.Email == email);
            if (contact != null)
            {
                _contacts.Remove(contact);
                _storage.SaveContacts(_contacts);
            }
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public Contact GetContactByEmail(string email)
        {
            return _contacts.FirstOrDefault(c => c.Email == email);
        }

        public void UpdateContact(Contact contact)
        {
            var existingContact = _contacts.FirstOrDefault(c => c.Email == contact.Email);
            if (existingContact != null)
            {
                _contacts.Remove(existingContact);
                _contacts.Add(contact);
                _storage.SaveContacts(_contacts);
            }
        }
    }
}
