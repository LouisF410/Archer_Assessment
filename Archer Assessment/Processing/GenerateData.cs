using Archer_Assessment.EntityModels;
using Archer_Assessment.Enums;
using System;
using System.Collections.Generic;

namespace Archer_Assessment.Processing
{
    public class GenerateData
    {
        private static readonly Random _random = new Random();

        public static List<ClientData> GenerateRandomData(Client client)
        {
            var clientData = new List<ClientData>();

            for (int i = 0; i < 100; i++)
            {
                var name = RandomNameGenerator.NameGenerator.Generate(RandomNameGenerator.Gender.Male);
                clientData.Add(new ClientData { ClientId = client.ClientId, Name = name, CellNumber = GeneratePhoneNumber(), Email = $"{name.ToLower().Replace(" ", "")}@{Enum.GetName(typeof(EmailProviders), _random.Next(4)).ToLower()}.com" });
            }

            return clientData;
        }

        private static string GeneratePhoneNumber()
        {
            string number = "0";

            for (int i = 0; i <= 10; i++)
            {
                number += _random.Next(9).ToString();
            }
            return number;
        }
    }


}
