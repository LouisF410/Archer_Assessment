using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer_Assessment.EntityModels
{
    public class ClientData
    {
        [Key]
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string CellNumber { get; set; }
        public string Email { get; set; }
    }
}
