namespace Archer_Assessment.Migrations
{
    using EntityModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AssessmentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Archer_Assessment.EntityModels.AssessmentContext";
        }

        protected override void Seed(AssessmentContext context)
        {
            context.MappingsProfiles.AddRange(new List<MappingProfile>()
            {
                new MappingProfile
                {
                    MappingProfileId = 1,
                    Format = FileFormat.Csv.ToString(),
                    Seperator = ",",
                    Mappings = new List<Mapping> {
                        new Mapping { DatabaseField = "Name", SourceField = "Name", Type = typeof(string).ToString() },
                        new Mapping { DatabaseField = "CellNumber", SourceField = "CellNumber", Type = typeof(string).ToString() },
                        new Mapping { DatabaseField = "Email", SourceField = "Email", Type = typeof(string).ToString() }
                    }
                },
                new MappingProfile
                {
                    MappingProfileId = 2,
                    Format = FileFormat.Json.ToString(),
                    Mappings = new List<Mapping> {
                        new Mapping { DatabaseField = "Name", SourceField = "Name", Type = typeof(string).ToString() },
                        new Mapping { DatabaseField = "CellNumber", SourceField = "CellNumber", Type = typeof(string).ToString() },
                        new Mapping { DatabaseField = "Email", SourceField = "Email", Type = typeof(string).ToString() }
                    }
                }
            });

            var client1 = new Client() { ClientName = "Client1", FileName = "Client1", MappingProfileId = 1 };
            context.Clients.Add(client1);

            var client2 = new Client() { ClientName = "Client2", FileName = "Client2", MappingProfileId = 2 };
            context.Clients.Add(client2);

            context.SaveChanges();
        }
    }
}
