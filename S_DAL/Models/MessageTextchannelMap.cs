using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S_DAL.Models
{
    [Table("MessageTextchannelMap")]
    public class MessageTextchannelMap
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("MessageId")]
        public Message Message { get; set; }

        [ForeignKey("TextChannelId")]
        public TextChannel TextChannel { get; set; }
    }
}
