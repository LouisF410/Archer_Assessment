namespace Archer_Assessment.Migrations
{
    using EntityModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Archer_Assessment.EntityModels.AssessmentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Archer_Assessment.EntityModels.AssessmentContext";
        }

        protected override void Seed(Archer_Assessment.EntityModels.AssessmentContext context)
        {
            var client1 = new Client() { ClientId = 1, ClientName = "Client1", FileName = "Client1" };
            context.Clients.Add(client1);

            var client2 = new Client() { ClientId = 2, ClientName = "Client2", FileName = "Client2" };
            context.Clients.Add(client2);

            context.MappingsProfiles.AddRange(new List<MappingProfile>()
            {
                new MappingProfile
                {
                    MappingProfileId = 1,
                    ClientId = client1.ClientId,
                    Format = FileFormat.Csv.ToString()
                },
                new MappingProfile
                {
                    MappingProfileId = 2,
                    ClientId = client2.ClientId,
                    Format = FileFormat.Json.ToString()
                }
            });

            context.Mappings.AddRange(new List<Mapping>
            {
                new Mapping { MappingId = 1, MappingProfileId = 1, Destination = "Name", Source = "Name", Type = typeof(string).ToString() },
                new Mapping { MappingId = 2, MappingProfileId = 1, Destination = "CellNumber", Source = "CellNumber", Type = typeof(string).ToString() },
                new Mapping { MappingId = 3, MappingProfileId = 1, Destination = "Email", Source = "Email", Type = typeof(string).ToString() },
                new Mapping { MappingId = 4, MappingProfileId = 2, Destination = "Name", Source = "Name", Type = typeof(string).ToString() },
                new Mapping { MappingId = 5, MappingProfileId = 2, Destination = "CellNumber", Source = "CellNumber", Type = typeof(string).ToString() },
                new Mapping { MappingId = 6, MappingProfileId = 2, Destination = "Email", Source = "Email", Type = typeof(string).ToString() }
            });

            context.SaveChanges();
        }
    }
}
