using System;
namespace GreenKingSolution
{
    public class WebBrowser
    {
        public enum BrowserName
        {
            Unknown,
            InternetExplorer,
            Chrome,
            Firefox,
            Safari,
            Edge
        }

        public BrowserName Name { get; set; }

        public int MajorVersion { get; set; }
    }
}