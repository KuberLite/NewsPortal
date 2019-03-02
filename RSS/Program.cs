using System;
using System.Text;
using System.Xml;

namespace NewsPortal.ConsoleSeed
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ParseRssFile());
        }

        private static string ParseRssFile()
        {
            XmlDocument rssXmlDoc = new XmlDocument();

            // Load the RSS file from the RSS URL
            rssXmlDoc.Load("http://habrahabr.ru/rss/");

            // Parse the Items in the RSS file
            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

            StringBuilder rssContent = new StringBuilder();

            // Iterate through the items in the RSS file
            foreach (XmlNode rssNode in rssNodes)
            {
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode != null ? rssSubNode.InnerText : "";

                rssContent.Append(link + "\n" + title + "\n\n");
            }

            // Return the string that contain the RSS items
            return rssContent.ToString();
        }

        private string SelectNode(string name)
        {
            return null;
        }
    }
}
