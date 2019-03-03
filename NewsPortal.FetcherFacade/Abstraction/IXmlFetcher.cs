using NewsPortal.FetcherFacade.Models;
using System.Collections.Generic;

namespace NewsPortal.FetcherFacade.Abstraction
{
    internal interface IXmlFetcher<TModel>
        where TModel : class, IModelFromXml
    {
        List<TModel> GetItems(string xmlContent, string containingNodeName);
    }
}
