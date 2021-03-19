using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module_3_Task_2_Vasylchenko.Models;

namespace Module_3_Task_2_Vasylchenko.Services
{
    public class ContactList
    {
        private SortedDictionary<string, List<Contact>> _countries;

        public ContactList()
        {
            _countries = new SortedDictionary<string, List<Contact>>();
        }

        public void AddContact(Contact contact, string language)
        {
            var flag = false;
            List<Contact> contacts = new List<Contact>();
            contacts.Add(contact);
            var key = contact.FullName.Substring(0, 1).ToUpper();
            for (var i = 0; i < language.Length; i++)
            {
                var kayLanguage = language[i].ToString();
                if (kayLanguage == key)
                {
                    if (Check(key))
                    {
                        Add(key, contact);
                        flag = true;
                    }
                    else
                    {
                        _countries.Add(key, contacts);
                        flag = true;
                    }
                }
            }

            if (flag == false && int.TryParse(key, out int numValue))
            {
                Skan("0-9");
            }
            else if (flag == false)
            {
                Skan("#");
            }

            void Skan(string kay)
            {
                if (Check(kay))
                {
                    Add(kay, contact);
                }
                else
                {
                    _countries.Add(kay, contacts);
                }
            }
        }

        public bool DeleteContact(string contact)
        {
            var key = contact.Substring(0, 1).ToUpper();
            foreach (KeyValuePair<string, List<Contact>> value in _countries)
            {
                if (value.Key == key)
                {
                    if (Feel(value.Key, contact))
                    {
                        return true;
                    }
                }
                else if (value.Key == "#")
                {
                    if (Feel(value.Key, contact))
                    {
                        return true;
                    }
                }
                else if (value.Key == "0-9")
                {
                    if (Feel(value.Key, contact))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public SortedDictionary<string, List<Contact>> Push()
        {
            return _countries;
        }

        public void ActionsChangingCulture(string cultureInfo)
        {
            SortedDictionary<string, List<Contact>> countries = _countries;
            _countries = new SortedDictionary<string, List<Contact>>();
            foreach (KeyValuePair<string, List<Contact>> contactsLetter in countries)
            {
                foreach (Contact contact in contactsLetter.Value)
                {
                    AddContact(contact, cultureInfo);
                }
            }
        }

        private bool Check(string kay)
        {
            if (_countries != null)
            {
                foreach (KeyValuePair<string, List<Contact>> value in _countries)
                {
                    if (value.Key == kay)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool Feel(string kay, string contact)
        {
            foreach (Contact i in _countries[kay])
            {
                if (i.FullName == contact)
                {
                    return Delete(kay, i);
                }
            }

            return false;
        }

        private void Add(string kay, Contact contact)
        {
            _countries[kay].Add(contact);
        }

        private bool Delete(string kay, Contact contact)
        {
            return _countries[kay].Remove(contact);
        }
    }
}
