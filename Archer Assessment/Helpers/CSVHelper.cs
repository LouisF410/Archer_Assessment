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
        public static DataTable ExtractCSVData(string filePath)
        {
            DataTable dt = new DataTable();

            using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(file);

                var headers = sr.ReadLine();
                dt.Columns.AddRange(headers.Split(',').Select(c => new DataColumn { ColumnName = c }).ToArray());

                while (!sr.EndOfStream)
                {
                    DataRow dr = dt.NewRow();
                    dr.ItemArray = sr.ReadLine().Split(',');
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        public static void OutputCSVData(dynamic data, MappingProfile profile)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in data)
            {

            }
        }   
    }
}
