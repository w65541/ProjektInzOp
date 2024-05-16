
using ProjektInzOp.Entitites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABAPP.Entities
{
    [Table("Borrows")]
    public class Borrow : BaseEntity
    {
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        [DefaultValue(0)]
        public long Fine { get; set; }
        [ForeignKey(nameof(BookId))]
        public long BookId { get; set; }
        public Book Book { get; set; }
        [ForeignKey(nameof(ReaderId))]
        public long ReaderId { get; set; }
        public Reader Reader { get; set; }
       
    }
}
