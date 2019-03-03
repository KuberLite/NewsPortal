using NewsPortal.FetcherFacade.Abstraction;
using System;
    
namespace NewsPortal.FetcherFacade.Models
{
    public class NewsFromXmlModel : IModelFromXml
    {
        public string Title { get; set; }

        public string Link { get; set; }

        public string Guid { get; set; }

        public string Description { get; set; }

        public DateTime PubDate { get; set; }

        public string Creator { get; set; }
    }
}
