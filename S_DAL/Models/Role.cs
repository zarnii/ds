using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S_DAL.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        public IList<User> Users { get; } = new List<User>();

        public IList<Permission> Permissions { get; } = new List<Permission>();

        public IList<TextChannel> TextChannels { get; } = new List<TextChannel>();
    }
}
