using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S_DAL.Models
{
    [Table("Permission")]
    public class Permission
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        public IList<Role> Roles { get; } = new List<Role>();
    }
}
