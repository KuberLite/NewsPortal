using NewsPortal.FetcherFacade;
using NewsPortal.NewsFeedSources.Interfaces;
using NewsPortal.NewsFeedSources.Properties;

namespace NewsPortal.NewsFeedSources
{
    public class HabraHabrFetcher : ConcreteFetcher, IHabraHabrFetcher
    {
        public override string FetchUri
        {
            get
            {
                return Settings.Default.HabraHabrNewsFeedUri;
            }
        }
    }
}
