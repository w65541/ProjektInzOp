using LABAPP.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektInzOp.Dto
{
    public class BookDto
    {
        public long Id { get; set; }
        public bool Borrowed { get; set; }

        
        public long TitleId { get; set; }
     

        
    }
}
