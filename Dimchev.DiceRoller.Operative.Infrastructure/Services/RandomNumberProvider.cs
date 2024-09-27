using Dimchev.DiceRoller.Operative.Core.Contracts.Services;

namespace Dimchev.DiceRoller.Operative.Infrastructure.Services
{
    public class RandomNumberProvider : IRandomNumberProvider
    {
        public int Next(int minValue, int maxValue)
        {
            return new Random().Next(minValue, maxValue);
        }
    }
}
