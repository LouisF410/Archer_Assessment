using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer_Assessment.EntityModels
{
    public class MappingProfile
    {
        [Key]
        public int MappingProfileId { get; set; }      
        public string Format { get; set; }
        public string Seperator { get; set; }
        public virtual ICollection<Mapping> Mappings { get; set; }
    }
}
