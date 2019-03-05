using NewsPortal.Domain.Entities;
using NewsPortal.ServicesFacade.Base;
using NewsPortal.ViewModel.Concrete;

namespace NewsPortal.ServicesFacade.Concrete
{
    public interface INewsService : IService<News, NewsViewModel>
    {
    }
}
