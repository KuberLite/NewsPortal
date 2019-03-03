using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
    
namespace NewsPortal.FetcherFacade
{
    [XmlType("item")]
    public class Items
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement("guid")]
        public string Guid { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("pubDate")]
        public DateTime PublishDate { get; set; }

        [XmlElement("dc:creator")]
        public string Creator { get; set; }
    }
}
