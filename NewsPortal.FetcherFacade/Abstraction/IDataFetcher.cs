using NewsPortal.FetcherFacade.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsPortal.FetcherFacade.Abstraction
{
    internal interface IDataFetcher<TModel>
        where TModel : class, IModelFromXml
    {
        Task<List<TModel>> GetListData(string uri);
    }
}
