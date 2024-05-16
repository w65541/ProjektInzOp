
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
    [Table("Books")]
    public class Book : BaseEntity
    {
        [DefaultValue(false)]
        public bool Borrowed { get; set; }

        [ForeignKey(nameof(TitleId))]
        public long TitleId { get; set; }
        public Title Title { get; set; }

        public ICollection<Borrow> Borrows { get; set; }
    }
}
