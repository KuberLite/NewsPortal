using AutoMapper;
using NewsPortal.Domain.Context;
using NewsPortal.Domain.Entities;
using NewsPortal.Services.Base;
using NewsPortal.ServicesFacade.Concrete;
using NewsPortal.ViewModel.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
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
                .Where(x => context.News.Any(y => y.Title == x.Title && y.Guid == y.Guid))
                .ToList();

            context.News.AddRange(mapper.Map<IEnumerable<News>>(newsToAdd));

            await context.SaveChangesAsync();

            return newsToAdd.Count;
        }
    }
}
