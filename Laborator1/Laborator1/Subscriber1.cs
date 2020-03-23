using System;

namespace Laborator1
{
    public class Subscriber1
    {
        private readonly SiteScannerPublisher SiteScannerPublisher;

        public Subscriber1(SiteScannerPublisher siteScannerPublisher)
        {
            SiteScannerPublisher = siteScannerPublisher;
            siteScannerPublisher.SiteChangedEvent += OnSiteChanged;
        }

        public void OnSiteChanged(string arg)
        {
            Console.WriteLine("Subscriber1 object: {0} has changed", arg);
        }
    }
}
