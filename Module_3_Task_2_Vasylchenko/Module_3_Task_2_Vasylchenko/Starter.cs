using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module_3_Task_2_Vasylchenko.Models;
using Module_3_Task_2_Vasylchenko.Services;
using Newtonsoft.Json;

namespace Module_3_Task_2_Vasylchenko
{
    public class Starter
    {
        private readonly Language _lang;
        private readonly CultureInfo _cult;
        private readonly ContactList _list;
        public Starter()
        {
            _lang = new Language();
            _cult = new CultureInfo();
            _list = new ContactList();
        }

        public void Run()
        {
            Console.WriteLine("Выберите культуру алфавита ");
            var culture = Console.ReadLine();
            _cult.DefinitionOfCulture(culture);
            Contact contact = new Contact();
            contact.FullName = "tjhv";
            contact.PhoneNumber = "+380999854175";
            Contact contact1 = new Contact();
            contact1.FullName = "8jhfghv";
            contact1.PhoneNumber = "+380999875";
            _list.AddContact(contact, _cult.Language);
            _list.AddContact(contact1, _cult.Language);

            Contact contact2 = new Contact();
            contact2.FullName = "3jhv";
            contact2.PhoneNumber = "+380999854175";
            Contact contact3 = new Contact();
            contact3.FullName = "Щjhfghv";
            contact3.PhoneNumber = "+380999875";
            _list.AddContact(contact2, _cult.Language);
            _list.AddContact(contact3, _cult.Language);

            foreach (KeyValuePair<string, List<Contact>> keyValue in _list.Push())
            {
                Console.WriteLine(keyValue.Key + " : ");
                foreach (Contact i in keyValue.Value)
                {
                    Console.WriteLine(i.FullName + " : " + i.PhoneNumber);
                }
            }

            _cult.ChangeCult("rus");
            _list.ActionsChangingCulture(_cult.Language);
            foreach (KeyValuePair<string, List<Contact>> keyValue in _list.Push())
            {
                Console.WriteLine(keyValue.Key + " : ");
                foreach (Contact i in keyValue.Value)
                {
                    Console.WriteLine(i.FullName + " : " + i.PhoneNumber);
                }
            }
        }
    }
}
