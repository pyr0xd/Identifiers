using ContactApp.Storage;
using Identifiers.Services;
using System;

namespace InfoNamesDataStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "kontakter.json"; // Ange sökväg till din JSON-fil
            var storage = new InfoNamesStorage(filePath);
            var service = new InfoNamesService(storage);

        }
    }
}