using Archer_Assessment.EntityModels;
using Archer_Assessment.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Archer_Assessment.Processing
{
    public class ProcessData
    {
        private readonly string filePath = $@"{Environment.CurrentDirectory}\MockData\";
        private readonly AssessmentContext db;

        public ProcessData()
        {
            db = new AssessmentContext();
        }

        public void Start()
        {
            var clients = db.Clients.Select(x => x);

            foreach (var client in clients)
            {
                var clientData = GenerateData.GenerateRandomData(client);

                if (client.MappingProfile.Format == FileFormat.Csv.ToString())
                {
                    CSVHelper.OutputCsvData($"{filePath}{client.ClientName}.{client.MappingProfile.Format}", GenerateCSVFileData(client, clientData));
                }
                else if (client.MappingProfile.Format == FileFormat.Json.ToString())
                {
                    JSONHelper.OutputJsonFile($"{filePath}{client.ClientName}.{client.MappingProfile.Format}", GenerateJsonFileData(client, clientData));
                }
            }

            foreach (var client in clients)
            {
                var data = new List<Dictionary<string, string>>();

                if (client.MappingProfile.Format == FileFormat.Csv.ToString())
                {
                    data = CSVHelper.ExtractCsvData($"{filePath}{client.FileName}.{client.MappingProfile.Format}",
                        client.MappingProfile.Seperator.ToCharArray()[0]);
                }
                else if (client.MappingProfile.Format == FileFormat.Json.ToString())
                {
                    data = JSONHelper.ExtractJsonData($"{filePath}{client.MappingProfile.Format}");     
                }

                SaveToDatabase(data, client);
            }

        }

        private string GenerateCSVFileData<T>(Client client, List<T> clientData)
        {
            var sb = new StringBuilder();
            var mappings = client.MappingProfile.Mappings;
            var properties = typeof(T).GetProperties();

            sb.AppendLine(string.Join(",", mappings.Select(map => map.SourceField)));

            foreach (var data in clientData)
            {
                sb.AppendLine(string.Join(",",
                    mappings.Select(x => properties.First((prop => prop.Name == x.DatabaseField)).GetValue(data))));
            }

            return sb.ToString();
        }

        private List<Dictionary<string,string>> GenerateJsonFileData<T>(Client client, List<T> clientData)
        {
            var mappings = client.MappingProfile.Mappings;
            var properties = typeof(T).GetProperties();

            return clientData.Select(data => mappings.ToDictionary(map => map.SourceField, map => properties.First(prop => prop.Name == map.DatabaseField).GetValue(data).ToString())).ToList();
        }

        private void SaveToDatabase(List<Dictionary<string, string>> data, Client client)
        {
            var mappings = client.MappingProfile.Mappings;

            var properties = typeof(ClientData).GetProperties();

            foreach (var d in data.ToList())
            {
                var cd = db.Data.Create();

                cd.ClientId = client.ClientId;

                //var cd = new ClientData {ClientId = client.ClientId};

                foreach (var map in mappings)
                {
                    var prop = properties.First(x => x.Name == map.DatabaseField);
                    prop.SetValue(cd, d[map.SourceField]);
                }
                db.Data.Add(cd);
                db.SaveChanges();
            }
            
        }
    }
}