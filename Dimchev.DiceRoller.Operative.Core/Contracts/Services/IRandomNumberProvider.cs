namespace Dimchev.DiceRoller.Operative.Core.Contracts.Services
{
    public interface IRandomNumberProvider
    {
        int Next(int minValue, int maxValue);
    }
}
