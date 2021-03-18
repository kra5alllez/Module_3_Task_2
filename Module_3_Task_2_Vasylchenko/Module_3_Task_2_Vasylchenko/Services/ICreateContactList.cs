using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module_3_Task_2_Vasylchenko.Models;

namespace Module_3_Task_2_Vasylchenko.Services
{
    public class ICreateContactList
    {
        private Dictionary<string, List<Contact>> _countries;

        public ICreateContactList()
        {
            _countries = new Dictionary<string, List<Contact>>(2);
        }

        public void AddContact(Contact contact, string lang)
        {
            var word = contact.FullName;
            var bukva = word.Substring(0, 1).ToUpper();
            for (var i = 0; i < lang.Length; i++)
            {
                var p = lang[i].ToString();
                if (p == bukva)
                {
                    List<Contact> contacts = new List<Contact>();
                    contacts.Add(contact);
                    _countries.Add(bukva, contacts);
                }
            }
        }

        public Dictionary<string, List<Contact>> Push()
        {
            return _countries;
        }
    }
}
