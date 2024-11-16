using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S_DAL.Models
{
    [Table("RequestToConnect")]
    public class RequestToConnect
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
    }
}
