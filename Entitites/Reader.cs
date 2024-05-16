
using ProjektInzOp.Entitites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABAPP.Entities
{
    [Table("Readers")]
    public class Reader : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }
        public long Phone { get; set; }
        public string Addres { get; set; }
        public ICollection<Borrow> Borrows { get; set; }
    }
}
