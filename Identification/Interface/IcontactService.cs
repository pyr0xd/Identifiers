using ContactApp.Models;
using System.Collections.Generic;

namespace ContactApp.Interfaces
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        void DeleteContact(string email);
        IEnumerable<Contact> GetAllContacts();
        Contact GetContactByEmail(string email);
        void UpdateContact(Contact contact);
        
    }
}


