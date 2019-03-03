using NewsPortal.FetcherFacade.Abstraction;
using NewsPortal.FetcherFacade.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsPortal.FetcherFacade
{
    public abstract class ConcreteFetcher : IConcreteFetcher
    {
        private readonly DataFetcher<NewsFromXmlModel> dataFetcher;

        public ConcreteFetcher()
        {
            dataFetcher = new DataFetcher<NewsFromXmlModel>();
        }

        protected abstract string FetchUri { get; }

        public async Task<List<NewsFromXmlModel>> GetNewsFeed()
        {
            return await dataFetcher.GetListData(FetchUri);
        }
    }
}
