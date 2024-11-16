using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S_DAL.Models
{
    [Table("Message")]
    public class Message
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column("Text")]
        public string Text { get; set; }

        [Required]
        [Column("AuthorId")]
        public Guid AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public User Author { get; set; }

        [Column("ReplyToId")]
        public Guid? ReplyToId { get; set; }

        [ForeignKey("ReplyToId")]
        public Message RepledTo { get; set; }

        [Required]
        [Column("SendTime")]
        public DateTime SendTime { get; set; }

        [Required]
        [Column("IsChanged")]
        public bool IsChanged { get; set; }


        public IList<TextChannel> TextChannels { get; } = new List<TextChannel>();
    }
}
