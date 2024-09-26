using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dimchev.DiceRoller.Operative.Core.Models
{
    [Table("DiceRolls")]
    public class DiceRollModel
    {
        [Key]
        public Guid DiceRollId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int FirstDice { get; set; }

        [Required]
        public int SecondDice { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
