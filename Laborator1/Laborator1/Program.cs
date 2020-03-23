using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Laborator1.PrimAlgorithms;

namespace Laborator1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Fir principal";

            Console.WriteLine($"\n0- Inchide program\n" +
                            $" 1- TryEvents() =>explicitarea folosirii eventurilor\n" +
                            $" 2- TryThreads() =>explicitarea threadurilor\n" +
                            $" 3- TryTasks() => explicitarea folosirii taskurilor\n" +
                            $" 4- TryEventBasedAsynchronousPattern() => explicitarea folosirii clasei Backgroundworker\n");
            int input = Int32.Parse(Console.ReadLine());
            while (input != 0)
            {
                if (input == 1)
                    TryEvents();
                else if (input == 2)
                    TryThreads();
                else if (input == 3)
                    TryTasks();
                else if (input == 4)
                    TryEventBasedAsynchronousPattern();

                Console.WriteLine($"\n COMENZI: \n0- Inchide program\n" +
                            $" 1- TryEvents() =>explicitarea folosirii eventurilor\n" +
                            $" 2- TryThreads() =>explicitarea threadurilor\n" +
                            $" 3- TryTasks() => explicitarea folosirii taskurilor\n" +
                            $" 4- TryEventBasedAsynchronousPattern() => explicitarea folosirii clasei Backgroundworker\n");
                input = Int32.Parse(Console.ReadLine());
            }     
        }

        public static  void TryEventBasedAsynchronousPattern()
        {
            List<string> commonResource = new List<string>();

            BackgroundWorker firstWorker = new BackgroundWorker() { WorkerReportsProgress = true };
            BackgroundWorker secondWorker = new BackgroundWorker() { WorkerReportsProgress = true };

            firstWorker.DoWork += FirstWorkerDoWork;
            firstWorker.RunWorkerAsync(commonResource);

            secondWorker.DoWork += SecondWorkerDoWork;
            secondWorker.RunWorkerAsync(commonResource);

            Console.WriteLine("Asteptam  8 secunde pentru a fi terminate operatiile asincrone executate de backgraoundworkeri !!");
            Thread.Sleep(8000);
            foreach (var info in commonResource)
            {
                Console.WriteLine(info);
            }
        }

        public static void FirstWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            var arg = (List<string>) e.Argument;
            FindingPrimNumber.IsPrim(9, arg);
        }

        public static void SecondWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            var arg = (List<string>)e.Argument;
            FindingPrimNumber.IsPrimInefficient(9, arg);
        }

        public  static void TryTasks()
        {
            List<string> commonResource = new List<string>();

           
            Console.WriteLine("Pornim primul task!");
            Task.Run(() => FindingPrimNumber.IsPrimInefficient(9, commonResource));

            Console.WriteLine("Pornim al II-lea task!");
            Task.Run(() => FindingPrimNumber.IsPrim(10, commonResource));

            Console.WriteLine("Asteptam  8 secunde pentru a fi terminate operatiile asincrone!");
            Thread.Sleep(7000);

            foreach (var info in commonResource)
            {
                Console.WriteLine(info);
            }
        }

        public static void TryThreads()
        {
            List<string> commonResource = new List<string>();
                
            Thread childThread = new Thread(() => FindingPrimNumber.IsPrimInefficient(10, commonResource));
            childThread.Name = "Child Thread";
            childThread.Start();

            FindingPrimNumber.IsPrim(9, commonResource);

            foreach (var info in commonResource)
            {
                Console.WriteLine(info);
            }
        }


        public static void TryEvents()
        {
            SiteScannerPublisher siteScanner = new SiteScannerPublisher();
            Subscriber1 subscriber1 = new Subscriber1(siteScanner);
            Subscriber2 subscriber2 = new Subscriber2(siteScanner);

            Console.WriteLine($"Publisherul invoca un event! info: Android site changed");
            siteScanner.OnAndroidSiteChanged();

            Console.WriteLine($"Publisherul invoca un event! info CN site chaged");
            siteScanner.OnCNSiteChanged();
        }
    }
}
