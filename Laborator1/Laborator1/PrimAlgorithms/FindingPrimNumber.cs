using System;
using System.Collections.Generic;
using System.Threading;

namespace Laborator1.PrimAlgorithms
{
    public class FindingPrimNumber
    {
        public static int IsPrimInefficient(int nr)
        {
            int searchedPrimNr = -1;
            for (var i = 2; i < nr; i++)
            {
                bool isPrim = true;

                for(var div = 2;div <=i/2; i++)
                    if (i % div == 0)
                        isPrim = false;
                if (isPrim == true)
                    searchedPrimNr = i;

            }

            return searchedPrimNr;
        }

        public  static void IsPrim(int nr, List<string> info)
        {
            DateTime start = DateTime.Today;
            info.Add("Start fir: " + Thread.CurrentThread.Name + DateTime.Now.ToString(" HH:mm:ss:mmm"));
            int searchedPrimNr = -1;
            int number = nr;
            while (nr > 2 && searchedPrimNr == -1)
            {
                nr--;
                bool isPrim = true;
                for (var div = 2; div <= nr / 2; div++)
                    if (nr % div == 0)
                        isPrim = false;
                if (nr == 2)
                    isPrim = true;
                if (isPrim == true)
                    searchedPrimNr = nr;
            }
            Thread.Sleep(2000);
            info.Add("End fir: " + Thread.CurrentThread.Name + " " +DateTime.Now.ToString(" HH:mm:ss:mmm"));
            // Console.WriteLine("Thread {0} : Numar prim mai mic decat {1} este: {2}", Thread.CurrentThread.Name, number, searchedPrimNr);
        }
    }
}
