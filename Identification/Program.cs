using ContactApp.Interfaces;
using ContactApp.Services;
using ContactApp.Storage;
using Identification.Interface;

namespace ContactApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IContactStorage storage = new JsonContactStorage("contacts.json");
            IContactService service = new ContactService(storage);

            ContactManager manager = new ContactManager(service);
            manager.Run();
        }
    }
}
