using Archer_Assessment.EntityModels;
using Archer_Assessment.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer_Assessment.Processing
{
    public class GenerateData
    {
        public GenerateData()
        {

        }

        public static void GenerateCSVData(Client client)
        {
            var clientData = new List<ClientData>();

            for (int i = 0; i <= 100; i++)
            {
                clientData.Add(new ClientData { ClientId = client.ClientId, Name = RandomNameGenerator.NameGenerator.Generate(RandomNameGenerator.Gender.Male), CellNumber = "", Email = "" });
            }

            var profile = client.MappingProfile;

            CSVHelper.OutputCSVData(clientData, profile);
        }
    }
}
