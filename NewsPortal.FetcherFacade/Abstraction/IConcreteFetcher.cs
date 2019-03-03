using NewsPortal.FetcherFacade.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsPortal.FetcherFacade.Abstraction
{
    public interface IConcreteFetcher
    {
        Task<List<NewsFromXmlModel>> GetNewsFeed();
    }
}
