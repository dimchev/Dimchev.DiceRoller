namespace Dimchev.DiceRoller.Operative.Core.Contracts.Services
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }
}
