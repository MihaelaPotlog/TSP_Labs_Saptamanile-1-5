using System;
using System.Collections.Generic;
using System.Threading;
using Laborator1.PrimAlgorithms;

namespace Laborator1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> commonRes = new List<string>();
            // UseEvents();
            Thread.CurrentThread.Name = "Fir principal";
            FindingPrimNumber algorithms = new FindingPrimNumber();

            Thread newThread = new Thread(()=> FindingPrimNumber.IsPrim(10, commonRes));
            newThread.Name = "Child Thread";
            newThread.Start();
            FindingPrimNumber.IsPrim(9, commonRes);
            foreach (var info in commonRes)
            {
                
                Console.WriteLine(info);
            }
        }

        public static void UseEvents()
        {
            SiteScannerPublisher siteScanner = new SiteScannerPublisher();
            Subscriber1 subscriber1 = new Subscriber1(siteScanner);
            Subscriber2 subscriber2 = new Subscriber2(siteScanner);

            siteScanner.OnAndroidSiteChanged();
            siteScanner.OnCNSiteChanged();
        }
    }
}
