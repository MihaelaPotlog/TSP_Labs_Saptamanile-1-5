using System;
using System.Collections.Generic;
using System.Threading;

namespace Laborator1.PrimAlgorithms
{
    public class FindingPrimNumber
    {
        public static void IsPrimInefficient(int nr, List<string> info)
        {
            info.Add($"Start fir: {Thread.CurrentThread.Name}  {DateTime.Now.ToString(" HH:mm:ss:mmm")}  " +
                   $"Numar natural dat = {nr}");

            int searchedPrimNr = -1;
            for (var i = 2; i < nr; i++)
            {
                bool isPrim = true;

                for(var div = 2;div <=i/2; div++)
                    if (i % div == 0)
                        isPrim = false;

                if (i == 2)
                    isPrim = true;

                if (isPrim == true)
                    searchedPrimNr = i;

            }
            info.Add($"End fir: {Thread.CurrentThread.Name}  {DateTime.Now.ToString(" HH:mm:ss:mmm")} Numar prim = {searchedPrimNr}");   
        }

        public  static void IsPrim(int nr, List<string> info)
        {
            
            DateTime start = DateTime.Today;
            info.Add($"Start fir: {Thread.CurrentThread.Name}  {DateTime.Now.ToString(" HH:mm:ss:mmm")}  " +
                $"Numar natural dat = {nr}");
           
            int searchedPrimNr = -1;
            
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
            
            info.Add($"End fir: {Thread.CurrentThread.Name}  {DateTime.Now.ToString(" HH:mm:ss:mmm")} Numar prim = {searchedPrimNr}");
        }
    }
}
