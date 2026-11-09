
namespace Blackjack.Domain
{
    public enum RoundState
    {
        WaitingToStart,
        InitialDealing,
        PlayerTurn,
        DealerTurn,
        Finished
    }
}
