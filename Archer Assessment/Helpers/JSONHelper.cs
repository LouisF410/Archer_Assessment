using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Archer_Assessment.Helpers
{
    public class JSONHelper
    {
        public static List<Dictionary<string, string>> ExtractJSONData(string filePath)
        {
            using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(file);
                var data = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(data);
            }
        }
    }
}
