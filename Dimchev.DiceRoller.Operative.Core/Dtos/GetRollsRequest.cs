namespace Dimchev.DiceRoller.Operative.Core.Dtos
{
    public class GetRollsRequest
    {
        public DateTime? Year { get; set; }

        public DateTime? Month { get; set; }

        public DateTime? Day { get; set; }

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public string SortBy { get; set; } = "createdAt";

        public bool Descending { get; set; } = false;
    }
}
