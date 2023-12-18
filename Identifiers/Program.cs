using System;

namespace InfoNamesDataStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataStorage dataStorage = new JsonDataStorage();

            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            InfoNames newInfoNames = new InfoNames(firstName, lastName, password);
            dataStorage.SaveInfoNames(newInfoNames);

            Console.WriteLine("InfoNames saved successfully.");
        }
    }
}