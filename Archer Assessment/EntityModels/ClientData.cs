using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Archer_Assessment.EntityModels
{
    [Table("ClientData")]
    public class ClientData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientDataId { get; set; }
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string CellNumber { get; set; }
        public string Email { get; set; }

        public string Result { get; set; }
    }
}
