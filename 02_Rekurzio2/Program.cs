using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Rekurzio2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tomb = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int hely;
            if (RekBinKer(tomb, 8, out hely))
            {
                Console.WriteLine(hely);
            }

            Console.ReadKey();
        }

        static bool RekBinKer(int[] tomb, int adat, out int hely)
        {
            return RekBinKer(tomb, adat, out hely, 0, tomb.Length - 1);
        }

        static bool RekBinKer(int[] tomb, int adat, out int hely, int E, int U)
        {
            if (E <= U)
            {
                int K = (E + U) / 2;
                if (tomb[K] > adat)
                {
                    return RekBinKer(tomb, adat, out hely, E, K - 1);
                }
                else
                {
                    if (tomb[K] < adat)
                    {
                        return RekBinKer(tomb, adat, out hely, K + 1, U);
                    }
                    else
                    {
                        hely = K;
                        return true;
                    }
                }
            }
            else
            {
                hely = -1;
                return false;
            }
        }
    }
}
