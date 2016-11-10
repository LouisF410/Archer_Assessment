using Archer_Assessment.EntityModels;
using Archer_Assessment.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Archer_Assessment.Processing
{
    /// <summary>
    /// Handles the processing of data
    /// </summary>
    public class ProcessData
    {
        private readonly string _filePath = $@"{Environment.CurrentDirectory}\MockData\";
        private const string _pattern = @"^(\d{10})$";

        public ProcessData()
        {
            if (!System.IO.Directory.Exists(_filePath)) System.IO.Directory.CreateDirectory(_filePath);
        }

        public void Start()
        {
            using (var db = new AssessmentContext())
            {
                var clients = db.Clients.Select(x => x);

                //Generate Data and push to files
                foreach (var client in clients)
                {
                    var clientData = GenerateData.GenerateRandomData(client);

                    if (client.MappingProfile.Format == FileFormat.Csv.ToString())
                    {
                        CsvHelper.OutputCsvData($"{_filePath}{client.ClientName}.{client.MappingProfile.Format}",
                            GenerateData.GenerateCSVFileData(client, clientData));
                    }
                    else if (client.MappingProfile.Format == FileFormat.Json.ToString())
                    {
                        JsonHelper.OutputJsonFile($"{_filePath}{client.ClientName}.{client.MappingProfile.Format}",
                            GenerateData.GenerateJsonFileData(client, clientData));
                    }
                }


                //Read Files and push to database
                foreach (var client in clients)
                {
                    var data = new List<Dictionary<string, string>>();

                    if (client.MappingProfile.Format == FileFormat.Csv.ToString())
                    {
                        data = CsvHelper.ExtractCsvData($"{_filePath}{client.FileName}.{client.MappingProfile.Format}",
                            client.MappingProfile.Seperator.ToCharArray()[0]);
                    }
                    else if (client.MappingProfile.Format == FileFormat.Json.ToString())
                    {
                        data = JsonHelper.ExtractJsonData($"{_filePath}{client.FileName}.{client.MappingProfile.Format}");
                    }

                    SaveToDatabase(data, client);
                }
            }
        }

        /// <summary>
        /// Save Data to Database
        /// </summary>
        /// <param name="data"></param>
        /// <param name="client"></param>
        private void SaveToDatabase(List<Dictionary<string, string>> data, Client client)
        {
            using (var db = new AssessmentContext())
            {
                var mappings = client.MappingProfile.Mappings;
                var properties = typeof(ClientData).GetProperties();

                foreach (var d in data.ToList())
                {
                    var cd = new ClientData {ClientId = client.ClientId};

                    foreach (var map in mappings)
                    {
                        var prop = properties.First(x => x.Name == map.DatabaseField);
                        prop.SetValue(cd, d[map.SourceField]);
                    }

                    cd.Result = $"[IsValid]={Regex.IsMatch(cd.CellNumber, _pattern)}";
                    db.Data.Add(cd);
                }

                db.SaveChanges();
            }
        }
    }
}