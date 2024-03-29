﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace logic
{
    public static class Shuffler
    {
        public static IEnumerable<T> Shuffle<T>(IList<T> list, int seed)
        {            
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = new Random(seed).Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list.AsEnumerable<T>();
        }
    }
}
