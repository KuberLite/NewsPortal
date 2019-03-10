using NewsPortal.Domain.Entities;
using NewsPortal.ViewModel.Base;
using NewsPortal.ViewModel.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
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

        Task<PageViewModel<TViewModel>> GetPage<TSortProperty>(int pageNumber, int itemPerPage, Expression<Func<TEntity, TSortProperty>> sortExpression, bool ascending = false);
    }
}
