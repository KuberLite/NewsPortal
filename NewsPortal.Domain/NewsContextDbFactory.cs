using NewsPortal.Domain.Context;
using System.Configuration;
using System.Data.Entity.Infrastructure;

namespace NewsPortal.Domain
{
    public class NewsContextFactory : IDbContextFactory<NewsContext>
    {
        public NewsContext Create()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["NewsContext"].ConnectionString;
            return new NewsContext(connectionString);
        }
    }
}
