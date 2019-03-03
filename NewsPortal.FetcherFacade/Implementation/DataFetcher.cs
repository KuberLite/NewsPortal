using NewsPortal.FetcherFacade.Abstraction;
using NewsPortal.FetcherFacade.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NewsPortal.FetcherFacade
{
    internal class DataFetcher<TModel> : IDataFetcher<TModel>
        where TModel : class, IModelFromXml
    {
        private readonly HttpClient httpClient;
        private readonly XmlFetcher<TModel> xmlFetcher;

        public DataFetcher()
        {
            httpClient = new HttpClient();
            xmlFetcher = new XmlFetcher<TModel>();
        }

        public async Task<List<TModel>> GetListData(string uri)
        {
            var content = await MakeRequest(uri);
            return xmlFetcher.GetItems(content, "item");
        }

        private async Task<string> MakeRequest(string uri)
        {
            var response = await httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    $"Unable to make request '{uri}'. Server returned: Status code: {response.StatusCode}, Phrase: {response.ReasonPhrase}"
                );
            }

            var stringContent = await response.Content.ReadAsStringAsync();
            return stringContent.TrimStart();
        }
    }
}
