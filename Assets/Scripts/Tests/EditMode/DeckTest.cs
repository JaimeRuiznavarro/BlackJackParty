
using System;
using System.Collections.Generic;
using NUnit.Framework;
using Blackjack.Domain;

namespace Blackjack.Domain.Tests
{
    public class DeckTests
    {
        // Generador determinista para que las pruebas sean reproducibles.
        private sealed class PredictableRandomSource : IRandomSource
        {
            public int Next(int maxExclusive)
            {
                return 0;
            }
        }

        [Test]
        public void DefaultDeck_Contains312Cards()
        {
            Deck deck = new Deck();

            Assert.AreEqual(312, deck.TotalCards);
            Assert.AreEqual(312, deck.RemainingCards);
        }

        [Test]
        public void SixDeckShoe_ContainsSixCopiesOfEveryCard()
        {
            Deck deck = new Deck(
                6,
                new PredictableRandomSource()
            );

            Dictionary<Card, int> occurrences =
                new Dictionary<Card, int>();

            for (int i = 0; i < 312; i++)
            {
                Card card = deck.DrawCard();

                if (!occurrences.ContainsKey(card))
                {
                    occurrences.Add(card, 0);
                }

                occurrences[card]++;
            }

            Assert.AreEqual(52, occurrences.Count);

            foreach (KeyValuePair<Card, int> entry in occurrences)
            {
                Assert.AreEqual(
                    6,
                    entry.Value,
                    $"Incorrect quantity for {entry.Key}"
                );
            }
        }

        [Test]
        public void DrawingCard_ReducesRemainingCards()
        {
            Deck deck = new Deck();

            deck.DrawCard();

            Assert.AreEqual(311, deck.RemainingCards);
        }

        [Test]
        public void DrawingAllCards_LeavesDeckEmpty()
        {
            Deck deck = new Deck();

            for (int i = 0; i < 312; i++)
            {
                deck.DrawCard();
            }

            Assert.AreEqual(0, deck.RemainingCards);
        }

        [Test]
        public void DrawingFromEmptyDeck_ThrowsException()
        {
            Deck deck = new Deck();

            for (int i = 0; i < 312; i++)
            {
                deck.DrawCard();
            }

            Assert.Throws<InvalidOperationException>(
                () => deck.DrawCard()
            );
        }

        [Test]
        public void CreatingDeckWithZeroDecks_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Deck(0)
            );
        }

        [Test]
        public void CreatingDeckWithNegativeDecks_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Deck(-1)
            );
        }

        [Test]
        public void CreatingDeckWithNullRandomSource_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(
                () => new Deck(6, null)
            );
        }

        [Test]
        public void Shuffle_PreservesAllCards()
        {
            Deck deck = new Deck(
                6,
                new PredictableRandomSource()
            );

            deck.Shuffle();

            Assert.AreEqual(312, deck.RemainingCards);

            Dictionary<Card, int> occurrences =
                new Dictionary<Card, int>();

            for (int i = 0; i < 312; i++)
            {
                Card card = deck.DrawCard();

                if (!occurrences.ContainsKey(card))
                {
                    occurrences.Add(card, 0);
                }

                occurrences[card]++;
            }

            Assert.AreEqual(52, occurrences.Count);

            foreach (int count in occurrences.Values)
            {
                Assert.AreEqual(6, count);
            }
        }
    }
}
