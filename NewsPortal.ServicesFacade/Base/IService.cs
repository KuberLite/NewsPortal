using NewsPortal.Domain.Entities;
using NewsPortal.ViewModel.Base;
using NewsPortal.ViewModel.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsPortal.ServicesFacade.Base
{
    public interface IService<TEntity, TViewModel>
        where TEntity : BaseEntity
        where TViewModel : IViewModel
    {
        Task<TViewModel> Find(params object[] keyValues);

        Task Add(TViewModel model);

        Task AddRange(IEnumerable<TViewModel> models);

        Task Remove(TViewModel model);

        Task RemoveRange(IEnumerable<TViewModel> models);

        Task<IEnumerable<TViewModel>> GetAll();

        Task<PageViewModel<TViewModel>> GetPage(int pageNumber, int itemPerPage);
    }
}
