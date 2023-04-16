using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class RandomNumber
    {
        private static readonly Random random = new Random();
        public static int GenerateNumber(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
