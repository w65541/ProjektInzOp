using System.ComponentModel.DataAnnotations;

namespace ProjektInzOp.Entitites
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
