using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S_DAL.Models
{
    [Table("RoleTextchannelMap")]
    public class RoleTextchannelMap
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }


        [ForeignKey("TextChannelId")]
        public TextChannel TextChannel { get; set; }
    }
}
