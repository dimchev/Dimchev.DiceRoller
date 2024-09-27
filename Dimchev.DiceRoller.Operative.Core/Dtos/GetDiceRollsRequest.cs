namespace Dimchev.DiceRoller.Operative.Core.Dtos
{
    public class GetDiceRollsRequest
    {
        public int? Year { get; set; }

        public int? Month { get; set; }

        public int? Day { get; set; }

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public string SortBy { get; set; } = "Sum";

        public bool Descending { get; set; } = false;
    }
}
