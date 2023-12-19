using ContactApp.Interfaces;
using ContactApp.Models;
using System;

namespace ContactApp
{  /// <summary>
   /// The ContactManager class provides a text-based user interface for managing contacts.
   /// It allows adding, removing, listing, and editing contacts via a console application.
   /// </summary>
    public class ContactManager
    {
        private readonly IContactService _service;

        public ContactManager(IContactService service)
        {
            _service = service;
        }

        /// <summary>
        /// Main loop for the contact management system. Provides a menu for user interaction.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                DisplayHeader("contact Managment System");
                Console.WriteLine("\nContact Management System");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Remove Contact");
                Console.WriteLine("3. List All Contacts");
                Console.WriteLine("4. Edit Contact");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                var option = Console.ReadLine();
                Console.Clear();

                switch (option)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        RemoveContact();
                        break;
                    case "3":
                        ListContacts();
                        break;
                    case "4":
                        EditContact();
                        break;
                    case "5":
                        return;
                    default:
                        DisplayHeader("Invalid Option");
                        Console.WriteLine("Invalid option. Please try again.");
                        Thread.Sleep(1000);

                        break;
                }
            }
        }


        private void AddContact()
        {
            DisplayHeader("Add Contact");

            var contact = new Contact();

            Console.Write("Enter First Name: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            contact.LastName = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            contact.PhoneNumber = Console.ReadLine();

            Console.Write("Enter Email: ");
            contact.Email = Console.ReadLine();

            Console.Write("Enter Address: ");
            contact.Address = Console.ReadLine();
            

            _service.AddContact(contact);
            Console.WriteLine("Contact added successfully.");
        }

        private void RemoveContact()
        {
            DisplayHeader("Remove Contact");

            Console.Write("Enter the Email of the contact to remove: ");
            string email = Console.ReadLine();
            _service.DeleteContact(email);
            Console.WriteLine("Contact removed if it existed.");
        }

        private void ListContacts()
        {
            DisplayHeader("List Contacts");

            var contacts = _service.GetAllContacts();
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}, Phone: {contact.PhoneNumber}, Email: {contact.Email}, Address: {contact.Address}");
               
            }
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }
        private void EditContact()
        {
            DisplayHeader("Edit Contact");

            Console.Write("Enter the Email of the contact to edit: ");
            string email = Console.ReadLine();

            var contact = _service.GetContactByEmail(email);
            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            Console.WriteLine("Leave blank if you do not wish to change the information.");

            Console.Write($"Enter new First Name (Current: {contact.FirstName}): ");
            var newFirstName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newFirstName))
            {
                contact.FirstName = newFirstName;
            }

            Console.Write($"Enter new Last Name (Current: {contact.LastName}): ");
            var newLastName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newLastName))
            {
                contact.LastName = newLastName;
            }

            Console.Write($"Enter new Phone Number (Current: {contact.PhoneNumber}): ");
            var newPhoneNumber = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newPhoneNumber))
            {
                contact.PhoneNumber = newPhoneNumber;
            }

            Console.Write($"Enter new Address (Current: {contact.Address}): ");
            var newAddress = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newAddress))
            {
                contact.Address = newAddress;
            }

            _service.UpdateContact(contact);
            Console.WriteLine("Contact updated successfully.");
        }
        /// <summary>
        /// Draws a border on the console for better visual organization.
        /// </summary>
        private void DisplayHeader(string title)
        {
            Console.Clear();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(title);
            Console.WriteLine(new string('-', 40));
        }


    }
}
