using System.ComponentModel.DataAnnotations;

namespace S_API.Models
{
    public class RequestToJoinData
    {
        [Required]
        public bool AcceptPolitics { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Login {  get; set; }

        [Required]
        public string UserPassword { get; set; }

        public string ServerPassword { get; set; }
    }
}
