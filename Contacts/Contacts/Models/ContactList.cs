using System;
using System.Collections.Generic;

namespace Contacts
{
    public class ContactList
    {
        private const string NUMBERS = "0-9";
        private const string SHARP = "#";

        private readonly SortedDictionary<string, List<Contact>> _items = new SortedDictionary<string, List<Contact>>();

        public ContactList(IEnumerable<Contact> contacts, string alphabet)
        {
            Add(contacts, alphabet);
        }

        public IEnumerator<KeyValuePair<string, List<Contact>>> GetEnumerator()
        {
            foreach (var item in _items)
            {
                yield return item;
            }
        }

        private void Add(IEnumerable<Contact> contacts, string alphabet)
        {
            foreach (var contact in contacts)
            {
                Add(contact, alphabet);
            }
        }

        private void Add(Contact contact, string alphabet)
        {
            if (alphabet.Contains(contact.FullName[0], StringComparison.OrdinalIgnoreCase))
            {
                Add(contact.FullName[0].ToString(), contact);
            }
            else if (char.IsDigit(contact.FullName[0]))
            {
                Add(NUMBERS, contact);
            }
            else
            {
                Add(SHARP, contact);
            }
        }

        private void Add(string symbol, Contact contact)
        {
            var key = symbol.ToUpper();
            if (_items.ContainsKey(key))
            {
                _items[key].Add(contact);
            }
            else
            {
                _items.Add(key, new List<Contact> { contact });
            }

            _items[key].Sort(new ContactFullNameComparer());
        }
    }
}
