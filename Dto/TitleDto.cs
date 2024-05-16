using LABAPP.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektInzOp.Dto
{
    public class TitleDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long AuthorId { get; set; }
    

    }
}
