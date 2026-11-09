using System;
using System.Collections.Generic;

namespace Blackjack.Domain
{
    public sealed class Deck
    {
        private readonly List<Card> cards;
        private readonly IRandomSource randomSource;

        public int TotalCards { get; }
        public int RemainingCards => cards.Count;

        public Deck(int numberOfDecks = 6)
            : this(numberOfDecks, new SystemRandomSource())
        {
        }

        public Deck(int numberOfDecks, IRandomSource randomSource)
        {
            if (numberOfDecks <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(numberOfDecks),
                    "The number of decks must be greater than zero."
                );
            }

            this.randomSource = randomSource ??
                throw new ArgumentNullException(nameof(randomSource));

            cards = new List<Card>(numberOfDecks * 52);

            CreateCards(numberOfDecks);

            TotalCards = cards.Count;

            Shuffle();
        }

        private void CreateCards(int numberOfDecks)
        {
            for (int deckIndex = 0; deckIndex < numberOfDecks; deckIndex++)
            {
                foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                {
                    foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                    {
                        cards.Add(new Card(suit, rank));
                    }
                }
            }
        }

        public void Shuffle()
        {
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = randomSource.Next(i + 1);

                Card temporary = cards[i];
                cards[i] = cards[j];
                cards[j] = temporary;
            }
        }

        public Card DrawCard()
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException(
                    "The deck has no remaining cards."
                );
            }

            int lastIndex = cards.Count - 1;

            Card drawnCard = cards[lastIndex];

            cards.RemoveAt(lastIndex);

            return drawnCard;
        }
    }
}