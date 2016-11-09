using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archer_Assessment.EntityModels
{
    public class Mapping
    {
        [Key]
        public int MappingId { get; set; }  
        public string SourceField { get; set; }
        public string DatabaseField { get; set; }
        public string Type { get; set; }
        public virtual MappingProfile MappingProfile { get; set; }
    }
}
