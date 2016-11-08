using System.ComponentModel.DataAnnotations;

namespace Archer_Assessment.EntityModels
{
    public class Mapping
    {
        [Key]
        public int MappingId { get; set; }
        public int MappingProfileId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Type { get; set; }
       
        public MappingProfile MappingProfile { get; set; }
    }
}
