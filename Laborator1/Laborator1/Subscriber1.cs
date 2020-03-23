using System;

namespace Laborator1
{
    public class Subscriber1
    {
        private readonly SiteScannerPublisher SiteScannerPublisher;

        public Subscriber1(SiteScannerPublisher siteScannerPublisher)
        {
            SiteScannerPublisher = siteScannerPublisher;
            siteScannerPublisher.SiteChangedEvent += OnSiteChangedHandler;
        }

        public void OnSiteChangedHandler(string arg)
        {
            Console.WriteLine("Subscriber1  handler for event SiteChanged was called! Info:{0} has changed\n\n", arg);
        }
    }
}
