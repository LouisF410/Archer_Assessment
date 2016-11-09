using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Bson;

namespace Archer_Assessment.Helpers
{
    public class JSONHelper
    {
        public static List<Dictionary<string, string>> ExtractJsonData(string filePath)
        {
            using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(file);
                var data = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(data);
            }
        }

        public static void OutputJsonFile(string filePath, List<Dictionary<string, string>> data)
        {
            if (File.Exists(filePath)) File.Delete(filePath);

            using (var file = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write))
            {
                var jsonString = JsonConvert.SerializeObject(data);

                var sw = new StreamWriter(file);

                sw.Write(jsonString);
                sw.Flush();
                file.Close();
            }
                
        }
    }
}
