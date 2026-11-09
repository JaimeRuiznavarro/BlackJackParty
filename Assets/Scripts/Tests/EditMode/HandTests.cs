
using NUnit.Framework;
using Blackjack.Domain;

namespace Blackjack.Domain.Tests
{
    public class HandTests
    {
        private Hand CreateHand(params Card[] cards)
        {
            Hand hand = new Hand();

            foreach (Card card in cards)
            {
                hand.AddCard(card);
            }

            return hand;
        }

        [Test]
        public void NewHand_IsEmpty()
        {
            Hand hand = new Hand();

            Assert.AreEqual(0, hand.Cards.Count);
            Assert.AreEqual(0, hand.TotalValue);
            Assert.IsFalse(hand.IsBust);
            Assert.IsFalse(hand.IsBlackjack);
            Assert.IsFalse(hand.IsSoft);
        }

        [Test]
        public void NumberCards_AreCountedCorrectly()
        {
            Hand hand = CreateHand(
                new Card(CardSuit.Hearts, CardRank.Five),
                new Card(CardSuit.Spades, CardRank.Seven)
            );

            Assert.AreEqual(12, hand.TotalValue);
        }

        [Test]
        public void FaceCards_AreWorthTenPoints()
        {
            Hand hand = CreateHand(
                new Card(CardSuit.Hearts, CardRank.Jack),
                new Card(CardSuit.Spades, CardRank.Queen)
            );

            Assert.AreEqual(20, hand.TotalValue);
        }

        [Test]
        public void AceAndSeven_IsSoftEighteen()
        {
            Hand hand = CreateHand(
                new Card(CardSuit.Hearts, CardRank.Ace),
                new Card(CardSuit.Spades, CardRank.Seven)
            );

            Assert.AreEqual(18, hand.TotalValue);
            Assert.IsTrue(hand.IsSoft);
        }

        [Test]
        public void AceAndEightAndFive_IsHardFourteen()
        {
            Hand hand = CreateHand(
                new Card(CardSuit.Hearts, CardRank.Ace),
                new Card(CardSuit.Spades, CardRank.Eight),
                new Card(CardSuit.Clubs, CardRank.Five)
            );

            Assert.AreEqual(14, hand.TotalValue);
            Assert.IsFalse(hand.IsSoft);
        }

        [Test]
        public void TwoAcesAndNine_AreWorthTwentyOne()
        {
            Hand hand = CreateHand(
                new Card(CardSuit.Hearts, CardRank.Ace),
                new Card(CardSuit.Spades, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Nine));

            Assert.AreEqual(21, hand.TotalValue);
            Assert.IsTrue(hand.IsSoft);
        }

        [Test]
        public void AceAndKing_IsNaturalBlackjack()
        {
            Hand hand = CreateHand(
                new Card(CardSuit.Hearts, CardRank.Ace),
                new Card(CardSuit.Spades, CardRank.King)
            );

            Assert.AreEqual(21, hand.TotalValue);
            Assert.IsTrue(hand.IsBlackjack);
        }

        [Test]
        public void ThreeCardsWorthTwentyOne_IsNotBlackjack()
        {
            Hand hand = CreateHand(
                new Card(CardSuit.Hearts, CardRank.Seven),
                new Card(CardSuit.Spades, CardRank.Seven),
                new Card(CardSuit.Clubs, CardRank.Seven)
            );

            Assert.AreEqual(21, hand.TotalValue);
            Assert.IsFalse(hand.IsBlackjack);
        }

        [Test]
        public void HandOverTwentyOne_IsBust()
        {
            Hand hand = CreateHand(
                new Card(CardSuit.Hearts, CardRank.King),
                new Card(CardSuit.Spades, CardRank.Seven),
                new Card(CardSuit.Clubs, CardRank.Six)
            );

            Assert.AreEqual(23, hand.TotalValue);
            Assert.IsTrue(hand.IsBust);
        }
    }
}
