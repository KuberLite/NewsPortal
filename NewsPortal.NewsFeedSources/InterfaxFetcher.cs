using NewsPortal.FetcherFacade;
using NewsPortal.NewsFeedSources.Interfaces;
using NewsPortal.NewsFeedSources.Properties;

namespace NewsPortal.NewsFeedSources
{
    public class InterfaxFetcher : ConcreteFetcher, IInterfaxFetcher
    {
        protected override string FetchUri
        {
            get
            {
                return Settings.Default.InterfaxNewsFeedUri;
            }
        }
    }
}
