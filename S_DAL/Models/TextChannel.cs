using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S_DAL.Models
{
    [Table("TextChannel")]
    public class TextChannel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        [Column("SlowModeTimeout")]
        public int? SlowModeTimeout { get; set; }

        public IList<Message> Messages { get; } = new List<Message>();

        public IList<Role> Roles { get; } = new List<Role>();
    }
}
