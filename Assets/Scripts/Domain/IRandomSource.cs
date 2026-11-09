namespace Blackjack.Domain
{
    public interface IRandomSource
    {
        int Next(int maxExclusive);
    }
}