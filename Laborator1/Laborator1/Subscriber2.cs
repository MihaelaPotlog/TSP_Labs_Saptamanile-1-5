using System;

namespace Laborator1
{
    public class Subscriber2
    {
        public SiteScannerPublisher SiteScannerPublisher { get; set; }

        public Subscriber2(SiteScannerPublisher siteScannerPublisher)
        {
            SiteScannerPublisher = siteScannerPublisher;
            siteScannerPublisher.SiteChangedEvent += OnSiteChangedHandler;
        }

        public void OnSiteChangedHandler(string arg)
        {
            Console.WriteLine("Subscriber2 object: {0} has changed",arg);
        }
    }
}
