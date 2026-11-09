using System;

namespace Blackjack.Domain
{
    public sealed class SystemRandomSource : IRandomSource
    {
        private readonly Random random;

        public SystemRandomSource()
        {
            random = new Random();
        }

        public int Next(int maxExclusive)
        {
            return random.Next(maxExclusive);
        }
    }
}