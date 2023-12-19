using ContactApp.Interfaces;
using ContactApp.Models;
using Identification.Interface;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ContactApp.Storage
{
    public class JsonContactStorage : IContactStorage
    {
        private readonly string _filePath;

        public JsonContactStorage(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<Contact> LoadContacts()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Contact>();
            }

            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<IEnumerable<Contact>>(json) ?? new List<Contact>();
        }

        public void SaveContacts(IEnumerable<Contact> contacts)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(contacts, options);
            File.WriteAllText(_filePath, json);
        }
    }
}
