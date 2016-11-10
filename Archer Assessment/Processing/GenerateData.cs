using Archer_Assessment.EntityModels;
using Archer_Assessment.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Archer_Assessment.Processing
{

    /// <summary>
    /// Responsible for data generation
    /// </summary>
    public class GenerateData
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// Get Data in Csv File Format
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="clientData"></param>
        /// <returns></returns>
        public static string GenerateCSVFileData<T>(Client client, List<T> clientData)
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


        /// <summary>
        /// Get Data in Json File Format
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="clientData"></param>
        /// <returns></returns>
        public static  List<Dictionary<string, string>> GenerateJsonFileData<T>(Client client, List<T> clientData)
        {
            var mappings = client.MappingProfile.Mappings;
            var properties = typeof(T).GetProperties();

            return clientData.Select(data => mappings.ToDictionary(map => map.SourceField, map => properties.First(prop => prop.Name == map.DatabaseField).GetValue(data).ToString())).ToList();
        }


        /// <summary>
        /// Generates Random data for processing
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
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
            var number = "0";

            for (int i = 0; i < 9; i++)
            {
                number += _random.Next(9).ToString();
            }
            return number;
        }
    }


}
