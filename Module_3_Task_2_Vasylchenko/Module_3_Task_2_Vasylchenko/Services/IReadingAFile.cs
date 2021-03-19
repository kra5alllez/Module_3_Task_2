using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module_3_Task_2_Vasylchenko.Models;
using Newtonsoft.Json;

namespace Module_3_Task_2_Vasylchenko.Services
{
    public class IReadingAFile
    {
        public Language InitCulture()
        {
            var cinfig = File.ReadAllText("config.json");
            var cons = JsonConvert.DeserializeObject<Language>(cinfig);
            return cons;
        }
    }
}
