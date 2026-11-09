
using NUnit.Framework;
using Blackjack.Domain;

namespace Blackjack.Domain.Tests
{
    public class CardTests
    {
        [Test]
        public void Cards_WithSameSuitAndRank_AreEqual()
        {
            // Arrange
            Card first = new Card(CardSuit.Hearts, CardRank.Ace);
            Card second = new Card(CardSuit.Hearts, CardRank.Ace);

            // Assert
            Assert.AreEqual(first, second);
            Assert.IsTrue(first == second);
        }

        [Test]
        public void Cards_WithDifferentSuits_AreNotEqual()
        {
            // Arrange
            Card first = new Card(CardSuit.Hearts, CardRank.Ace);
            Card second = new Card(CardSuit.Spades, CardRank.Ace);

            // Assert
            Assert.AreNotEqual(first, second);
        }

        [Test]
        public void Cards_WithDifferentRanks_AreNotEqual()
        {
            // Arrange
            Card first = new Card(CardSuit.Hearts, CardRank.Ace);
            Card second = new Card(CardSuit.Hearts, CardRank.King);

            // Assert
            Assert.AreNotEqual(first, second);
        }

        [Test]
        public void EqualCards_HaveSameHashCode()
        {
            // Arrange
            Card first = new Card(CardSuit.Diamonds, CardRank.Ten);
            Card second = new Card(CardSuit.Diamonds, CardRank.Ten);

            // Assert
            Assert.AreEqual(
                first.GetHashCode(),
                second.GetHashCode()
            );
        }
    }
}
