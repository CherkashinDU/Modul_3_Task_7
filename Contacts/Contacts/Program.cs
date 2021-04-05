using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Contacts.Extensions;

namespace Contacts
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var configurationService = new ConfigurationService();
            var settings = configurationService.GetContactSettings();
            var contacts = GetContactList();

            ShowContactList("en-US", settings, contacts);
            ShowContactList("ru-RU", settings, contacts);
            ShowContactList("da-DK", settings, contacts);

            Console.ReadLine();
        }

        private static void ShowContactList(string culture, ContactSettings settings, List<Contact> contacts)
        {
            var alphabet = settings.Alphabet.GetOrDefault(culture, settings.DefaultCulture);
            var contactList = new ContactList(contacts, alphabet);

            Console.WriteLine($"Culture {culture}{Environment.NewLine}");

            foreach (var item in contactList)
            {
                foreach (var contact in item.Value)
                {
                    Console.WriteLine($"{item.Key} {contact.FullName} {contact.PhoneNumber}");
                }
            }

            Console.WriteLine(Environment.NewLine);
        }

        private static List<Contact> GetContactList()
        {
            return new List<Contact>
            {
                new Contact
            {
                FirstName = "Bilbo",
                LastName = "Baggins",
                PhoneNumber = "0576364873"
            },
                new Contact
            {
                FirstName = "Luke",
                LastName = "Skywalker",
                PhoneNumber = "0638158536"
            },
                new Contact
            {
                FirstName = "Gandalf ",
                LastName = "the grey",
                PhoneNumber = "0636548121"
            },
                new Contact
            {
                FirstName = "Leia",
                LastName = "Princess",
                PhoneNumber = "050264589"
            },
                new Contact
            {
                FirstName = "Chewbacca",
                PhoneNumber = "050264589"
            },
                new Contact
            {
                FirstName = "Frodo",
                LastName = "Baggins",
                PhoneNumber = "0576364873"
            },
                new Contact
            {
                FirstName = "Александр",
                LastName = "Пушкин",
                PhoneNumber = "0576364873"
            },
                new Contact
            {
                FirstName = "12312312312",
                PhoneNumber = "12312312312"
            }
            };
        }
    }
}
