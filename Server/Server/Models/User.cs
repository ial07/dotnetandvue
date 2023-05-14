using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class User :BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        
    }
}
