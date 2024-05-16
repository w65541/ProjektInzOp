
using ProjektInzOp.Entitites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABAPP.Entities
{
    [Table("Titles")]
    public class Title : BaseEntity
    {
        public string Name { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public long AuthorId { get; set; }
        public Author Author { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
