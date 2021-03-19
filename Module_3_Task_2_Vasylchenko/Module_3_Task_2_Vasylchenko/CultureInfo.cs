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
    public class CultureInfo
    {
        private readonly string _eng = "eng";
        private bool _flag = false;
        public string Language { get; set; } = "eng";

        public void DefinitionOfCulture(string cult)
        {
            var infoCult = InitCulture();
            foreach (KeyValuePair<string, string> keyCulture in infoCult.Lang)
            {
                if (keyCulture.Key == cult)
                {
                    _flag = true;
                    Language = keyCulture.Value;
                }
            }

            if (_flag == false)
            {
                foreach (KeyValuePair<string, string> keyCulture in infoCult.Lang)
                {
                    if (keyCulture.Key == _eng)
                    {
                        Language = keyCulture.Value;
                    }
                }
            }
        }

        public void ChangeCult(string cult)
        {
            DefinitionOfCulture(cult);
        }

        private Language InitCulture()
        {
            IReadingAFile libraylanguage = new IReadingAFile();
            return libraylanguage.InitCulture();
        }
    }
}
