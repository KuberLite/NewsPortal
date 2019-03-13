using AutoMapper;
using NewsPortal.Common.Extensions;
using NewsPortal.Common.Filters;
using NewsPortal.Domain.Context;
using NewsPortal.Domain.Entities;
using NewsPortal.Services.Base;
using NewsPortal.ServicesFacade.Concrete;
using NewsPortal.ViewModel.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NewsPortal.Services.Concrete
{
    public class NewsService : Service<News, NewsViewModel>, INewsService
    {
        protected readonly NewsContext _context;

        public NewsService(NewsContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<int> AddNewsFeed(IEnumerable<NewsViewModel> news)
        {
            await context.News.LoadAsync();

            var newsToAdd = news
                .Where(x => !context.News.Any(y => y.Title == x.Title && y.Guid == x.Guid))
                .ToList();

            context.News.AddRange(mapper.Map<IEnumerable<News>>(newsToAdd));

            await context.SaveChangesAsync();

            return newsToAdd.Count;
        }
        
        public async Task<PageViewModel<NewsViewModel>> GetFilteredNews(NewsFilter filter)
        {
            filter.Page = filter.Page ?? 1;
            filter.ItemsPerPage =
                filter.ItemsPerPage ?? Convert.ToInt32(ConfigurationManager.AppSettings["DefaultNumberOfItemsPerPage"]);

            var newsSourceString = filter.Source?.GetDescription();
            var newsSortString = filter.Sorting?.ToString();

            Expression<Func<News, bool>> newsSortExpression;
            Expression<Func<News, DateTime>> newsSortByDateExpression;
            Expression<Func<News, string>> newsSortBySourceExpression;

            if (string.IsNullOrEmpty(newsSourceString))
            {
                newsSortExpression = x => true;
            }
            else 
            {
                newsSortExpression = x => x.Link.Contains(newsSourceString);
            }

            if (newsSortString == "Date")
            { 
                return await GetPage(
                    filter.Page.Value,
                    filter.ItemsPerPage.Value,
                    newsSortExpression,
                    newsSortByDateExpression = x => x.PubDate
                    );
            }
            else if(newsSortString == "Source")
            {
                return await GetPage(
                    filter.Page.Value,
                    filter.ItemsPerPage.Value,
                    newsSortExpression,
                    newsSortBySourceExpression = x => x.Link
                    ); 
            }
            else
            {
                return await GetPage(
                    filter.Page.Value,
                    filter.ItemsPerPage.Value,
                    newsSortExpression,
                    x => x.Title
                    );

            }
        }
    }
}
