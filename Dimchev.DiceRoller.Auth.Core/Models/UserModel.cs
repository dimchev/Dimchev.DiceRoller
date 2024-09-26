using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dimchev.DiceRoller.Auth.Infrastructure.Models
{
    [Table("Users")]
    public class UserModel
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Email { get; set; }

        [Required]
        [MaxLength(4000)]
        public string Password { get; set; }

        public byte[] Image { get; set; }
    }
}
