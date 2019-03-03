using System;
using System.IO;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;

namespace NewsPortal.FetcherFacade
{
    public class Read
    {
        public async static Task GetRequest(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            HttpContent content = responseMessage.Content;
            string mycontent = await content.ReadAsStringAsync();
            mycontent = mycontent.TrimStart();
            StringReader reader = new StringReader(mycontent);
            XmlReader xmlReader = XmlReader.Create(reader);
            SyndicationFeed channel = SyndicationFeed.Load(xmlReader);
        }
    }
}
