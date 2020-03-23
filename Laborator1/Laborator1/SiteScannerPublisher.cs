namespace Laborator1
{
    public class SiteScannerPublisher
    {
        public delegate void SiteChanged(string arg);
        public event SiteChanged SiteChangedEvent;

        public void OnAndroidSiteChanged()
        {
            SiteChangedEvent?.Invoke("Android Site");
        }

        public void OnCNSiteChanged()
        {
            SiteChangedEvent?.Invoke("CN site");
        }
    }
}
