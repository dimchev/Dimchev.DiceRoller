using Dimchev.DiceRoller.Operative.Core.Contracts.Services;

namespace Dimchev.DiceRoller.Operative.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;

        public DateTime UtcNow => DateTime.UtcNow;
    }
}
