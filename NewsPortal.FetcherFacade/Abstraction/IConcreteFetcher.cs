using NewsPortal.FetcherFacade.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsPortal.FetcherFacade.Abstraction
{
    public interface IConcreteFetcher
    {
        string FetchUri { get; }

        Task<List<NewsFromXmlModel>> GetNewsFeed();
    }
}
