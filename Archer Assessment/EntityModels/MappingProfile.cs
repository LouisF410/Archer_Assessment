using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer_Assessment.EntityModels
{
    public class MappingProfile
    {
        [Key]
        public int MappingProfileId { get; set; }
        public int ClientId { get; set; }
        public IQueryable<Mapping> Mappings { get; set; }
        public string Format { get; set; }
    }
}
