
namespace Blackjack.Domain
{
    public sealed class BlackjackRules
    {
        // Baraja
        public int NumberOfDecks { get; }

        // Reglas del crupier
        public bool DealerStandsOnSoft17 { get; }

        // Pagos
        public int BlackjackPayoutNumerator { get; }
        public int BlackjackPayoutDenominator { get; }

        // Doblar
        public bool AllowDoubleDown { get; }
        public bool DoubleDownOnlyOnFirstTwoCards { get; }

        // Split
        public bool AllowSplit { get; }
        public bool AllowSplitByValue { get; }
        public int MaximumHandsPerPlayer { get; }
        public bool AllowSplittingAces { get; }
        public int CardsDealtToSplitAces { get; }
        public bool AllowResplittingAces { get; }

        // Otras reglas
        public bool AllowInsurance { get; }
        public bool AllowSurrender { get; }

        public BlackjackRules()
        {
            NumberOfDecks = 6;

            DealerStandsOnSoft17 = true;

            BlackjackPayoutNumerator = 3;
            BlackjackPayoutDenominator = 2;

            AllowDoubleDown = true;
            DoubleDownOnlyOnFirstTwoCards = true;

            AllowSplit = true;
            AllowSplitByValue = true;
            MaximumHandsPerPlayer = 4;
            AllowSplittingAces = true;
            CardsDealtToSplitAces = 1;
            AllowResplittingAces = false;

            AllowInsurance = false;
            AllowSurrender = false;
        }
    }
}
