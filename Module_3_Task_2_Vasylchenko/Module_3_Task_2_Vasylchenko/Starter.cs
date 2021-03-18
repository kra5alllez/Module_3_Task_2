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
        private readonly ICreateContactList _list;
        public Starter()
        {
            _lang = new Language();
            _cult = new CultureInfo();
            _list = new ICreateContactList();
        }

        public void Run()
        {
            Console.WriteLine("Выберите культуру алфавита ");
            var culture = Console.ReadLine();
            var language = _cult.DefinitionOfCulture(culture);
            Contact contact = new Contact();
            contact.FullName = "Tjhv";
            _list.AddContact(contact, language);
            var d = _list.Push();
            Console.WriteLine(language);
            foreach (KeyValuePair<string, List<Contact>> keyValue in d)
            {
                Console.WriteLine(keyValue.Key + " : ");
                foreach (Contact i in keyValue.Value)
                {
                    Console.WriteLine(i.FullName);
                }
            }
        }
    }
}
