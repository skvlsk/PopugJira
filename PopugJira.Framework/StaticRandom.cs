using System;
using System.Threading;

namespace PopugJira.Framework
{
    public static class StaticRandom
    {
        private static int seed = Environment.TickCount;

        private static readonly ThreadLocal<Random> Random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

        public static int Next(int from, int to)
        {
            return Random.Value.Next(from, to);
        }
    }
}