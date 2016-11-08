using System;
using System.ComponentModel.DataAnnotations;

namespace Archer_Assessment.EntityModels
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }     
        public string ClientName { get; set; }
        public string FileName { get; set; }
        
        public MappingProfile MappingProfile { get; set; }
    }

}
