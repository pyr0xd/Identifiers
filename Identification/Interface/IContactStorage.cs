using ContactApp.Models;
using System.Collections.Generic;

namespace Identification.Interface
{
    public interface IContactStorage
    {
        void SaveContacts(IEnumerable<Contact> contacts);
        IEnumerable<Contact> LoadContacts();
    }
}
