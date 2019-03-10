using NewsPortal.Common.Filters;
using NewsPortal.Domain.Entities;
using NewsPortal.ServicesFacade.Base;
using NewsPortal.ViewModel.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsPortal.ServicesFacade.Concrete
{
    public interface INewsService : IService<News, NewsViewModel>
    {
        Task<int> AddNewsFeed(IEnumerable<NewsViewModel> news);

        Task<PageViewModel<NewsViewModel>> GetFilteredNews(NewsFilter filter);
    }
}