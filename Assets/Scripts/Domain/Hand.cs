
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Blackjack.Domain
{
    public sealed class Hand
    {
        private readonly List<Card> cards;
        private readonly ReadOnlyCollection<Card> readOnlyCards;

        public IReadOnlyList<Card> Cards => readOnlyCards;

        public int TotalValue
        {
            get
            {
                int total = 0;
                int aceCount = 0;

                foreach (Card card in cards)
                {
                    if (card.Rank == CardRank.Ace)
                    {
                        // Primero contamos todos los Ases como 1.
                        total += 1;
                        aceCount++;
                    }
                    else if (
                        card.Rank == CardRank.Jack ||
                        card.Rank == CardRank.Queen ||
                        card.Rank == CardRank.King
                    )
                    {
                        // Las figuras valen 10 puntos.
                        total += 10;
                    }
                    else
                    {
                        // Las cartas del 2 al 10 valen su número.
                        total += (int)card.Rank;
                    }
                }

                // Intentamos convertir un As de 1 a 11.
                // Esto añade 10 puntos adicionales.
                if (aceCount > 0 && total + 10 <= 21)
                {
                    total += 10;
                }

                return total;
            }
        }

        public bool IsSoft
        {
            get
            {
                int total = 0;
                int aceCount = 0;

                foreach (Card card in cards)
                {
                    if (card.Rank == CardRank.Ace)
                    {
                        total += 1;
                        aceCount++;
                    }
                    else if (
                        card.Rank == CardRank.Jack ||
                        card.Rank == CardRank.Queen ||
                        card.Rank == CardRank.King
                    )
                    {
                        total += 10;
                    }
                    else
                    {
                        total += (int)card.Rank;
                    }
                }

                return aceCount > 0 && total + 10 <= 21;
            }
        }

        public bool IsBust => TotalValue > 21;

        public bool IsBlackjack =>
            cards.Count == 2 && TotalValue == 21;

        public Hand()
        {
            cards = new List<Card>();
            readOnlyCards = cards.AsReadOnly();
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }
    }
}
