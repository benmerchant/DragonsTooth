using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsTooth
{
    class dieRoller
    {

        public static int roll()
        {
            return StaticRandom.Instance.Next(1, 7);
        }
        public static int roll(int x)
        {
            return StaticRandom.Instance.Next(1, x + 1);
        }
        public static int roll(int n, int s)
        {
            int diceRoll;
            int diceSum = 0;

            while (n != 0)
            {
                diceRoll = StaticRandom.Instance.Next(1, s+1);
                diceSum += diceRoll;
                n--;
            }
            return diceSum;
        }
        public static int roll(int n, int s, int r)
        {
            int numMatch = 0;
            int diceRoll;

            while (n > 0)
            {
                diceRoll = StaticRandom.Instance.Next(1, s+1);
                if (diceRoll >= r)
                    numMatch++;
                n--;
            }

            Console.WriteLine();

            return numMatch;
        }


    }
}
