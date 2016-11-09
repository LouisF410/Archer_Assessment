using System.Collections.Generic;
using Archer_Assessment.EntityModels;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace Archer_Assessment.Helpers
{
    public class CSVHelper
    {
        public static List<Dictionary<string, string>> ExtractCsvData(string filePath, char seperator)
        {
            var result = new List<Dictionary<string, string>>();

            using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var sr = new StreamReader(file);
                var properties = sr.ReadLine().Split(seperator);


                while (!sr.EndOfStream)
                {
                    var a = new Dictionary<string, string>();
                    var items = sr.ReadLine().Split(seperator);
                    for (var i = 0; i < properties.Length; i++)
                    {
                        a.Add(properties[i], items[i]);
                    }

                    result.Add(a);
                }
            }

            return result;
        }

        public static void OutputCsvData(string filePath, string data)
        {
            if (File.Exists(filePath)) File.Delete(filePath);

            using (var file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                var sw = new StreamWriter(file);

                sw.Write(data);

                sw.Flush();
                file.Close();
            }
        }   
    }
}
