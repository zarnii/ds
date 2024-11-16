using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S_DAL.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column("Username")]
        public string Username { get; set; }

        [Required]
        [Column("Login")]
        public string Login { get; set; }

        [Required]
        [Column("Password")]
        public string Password { get; set; }

        
        [Column("Identity")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public long Identity { get; set; }

        public IList<Message> Messages { get; } = new List<Message>();

        public IList<Role> Roles { get; } = new List<Role>();
    }
}
