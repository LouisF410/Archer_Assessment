namespace Archer_Assessment.EntityModels
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AssessmentContext : DbContext
    {
        // Your context has been configured to use a 'DBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Archer_Assessment.EntityModels.DBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DBContext' 
        // connection string in the application configuration file.
        public AssessmentContext()
            : base("name=AssessmentContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientData> Data { get; set; }
        public DbSet<MappingProfile> MappingsProfiles { get; set; }
        public DbSet<Mapping> Mappings { get; set; }
    }
}