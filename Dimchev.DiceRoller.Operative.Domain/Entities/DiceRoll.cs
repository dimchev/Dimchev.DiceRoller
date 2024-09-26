namespace Dimchev.DiceRoller.Operative.Domain.Entities
{
    public class DiceRoll
    {
        public Guid DiceRollId { get; set; }

        public int FirstDice { get; set; }

        public int SecondDice { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Sum => FirstDice + SecondDice;
    }
}
