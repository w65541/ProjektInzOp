
using ProjektInzOp.Entitites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABAPP.Entities
{
    [Table("Authors")]
    public class Author : BaseEntity
    {
        
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<Title> Titles { get; set; }
    }
}
