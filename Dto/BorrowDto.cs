using LABAPP.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ProjektInzOp.Dto
{
    public class BorrowDto
    {
        public long Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        
        public long Fine { get; set; }
        
        public long BookId { get; set; }
        
        
        public long ReaderId { get; set; }
        
    }
}
