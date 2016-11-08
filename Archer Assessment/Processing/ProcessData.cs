using Archer_Assessment.EntityModels;
using Archer_Assessment.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

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
                GenerateData.GenerateCSVData(client);
            }

           // var data = CSVHelper.ExtractCSVData($"{filePath}Client1.csv");

            //var data2 = JSONHelper.ExtractJSONData($"{filePath}Client2.json");
        }
    }
}
