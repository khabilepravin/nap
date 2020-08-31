using System;
using System.Collections.Generic;
using System.Linq;

namespace logic
{
    public static class ThreadSafeRandom
    {
        [ThreadStatic] private static Random Local;
        public static int seed = 0;
        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(seed)); }            
        }
    }

    public static class Shuffler
    {
        public static IEnumerable<T> Shuffle<T>(IList<T> list, int seed)
        {
            ThreadSafeRandom.seed = seed;
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list.AsEnumerable<T>();
        }
    }
}
