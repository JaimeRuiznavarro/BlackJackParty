
using NUnit.Framework;
using Blackjack.Domain;

namespace Blackjack.Domain.Tests
{
    public class BlackjackRulesTests
    {
        private BlackjackRules rules;

        [SetUp]
        public void SetUp()
        {
            rules = new BlackjackRules();
        }

        [Test]
        public void DefaultRules_UseSixDecks()
        {
            Assert.AreEqual(6, rules.NumberOfDecks);
        }

        [Test]
        public void Dealer_StandsOnSoft17()
        {
            Assert.IsTrue(rules.DealerStandsOnSoft17);
        }

        [Test]
        public void NaturalBlackjack_PaysThreeToTwo()
        {
            Assert.AreEqual(3, rules.BlackjackPayoutNumerator);
            Assert.AreEqual(2, rules.BlackjackPayoutDenominator);
        }

        [Test]
        public void DoubleDown_IsAllowedOnlyOnFirstTwoCards()
        {
            Assert.IsTrue(rules.AllowDoubleDown);
            Assert.IsTrue(rules.DoubleDownOnlyOnFirstTwoCards);
        }

        [Test]
        public void Splitting_IsAllowedByValue()
        {
            Assert.IsTrue(rules.AllowSplit);
            Assert.IsTrue(rules.AllowSplitByValue);
        }

        [Test]
        public void MaximumHandsPerPlayer_IsFour()
        {
            Assert.AreEqual(4, rules.MaximumHandsPerPlayer);
        }

        [Test]
        public void SplitAces_ReceiveOnlyOneAdditionalCard()
        {
            Assert.IsTrue(rules.AllowSplittingAces);
            Assert.AreEqual(1, rules.CardsDealtToSplitAces);
        }

        [Test]
        public void SplitAces_CannotBeSplitAgain()
        {
            Assert.IsFalse(rules.AllowResplittingAces);
        }

        [Test]
        public void InsuranceAndSurrender_AreDisabled()
        {
            Assert.IsFalse(rules.AllowInsurance);
            Assert.IsFalse(rules.AllowSurrender);
        }
    }
}
