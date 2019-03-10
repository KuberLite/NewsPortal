using AutoMapper;
using NewsPortal.Domain.Context;
using NewsPortal.Domain.Entities;
using NewsPortal.ServicesFacade.Base;
using NewsPortal.ViewModel.Base;
using NewsPortal.ViewModel.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NewsPortal.Services.Base
{
    public abstract class Service<TEntity, TViewModel> : IService<TEntity, TViewModel>
        where TEntity : BaseEntity
        where TViewModel : IViewModel
    {
        protected readonly NewsContext context;
        protected readonly IMapper mapper;

        public Service(NewsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<TViewModel> Find(params object[] keyValues)
        {
            var entity = await context.Set<TEntity>().FindAsync(keyValues);
            return mapper.Map<TViewModel>(entity);
        }

        public async Task Add(TViewModel model)
        {
            var entity = mapper.Map<TEntity>(model);
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<TViewModel> models)
        {
            var entities = mapper.Map<IEnumerable<TEntity>>(models);
            context.Set<TEntity>().AddRange(entities);
            await context.SaveChangesAsync();
        }

        public async Task Remove(TViewModel model)
        {
            var entity = mapper.Map<TEntity>(model);
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<TViewModel> models)
        {
            var entities = mapper.Map<IEnumerable<TEntity>>(models);
            context.Set<TEntity>().RemoveRange(entities);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TViewModel>> GetAll()
        {
            var entities = await context.Set<TEntity>().ToListAsync();
            return mapper.Map<IEnumerable<TViewModel>>(entities);
        }

        public async Task<PageViewModel<TViewModel>> GetPage<TSortProperty>(int pageNumber, int itemPerPage,
            Expression<Func<TEntity, TSortProperty>> sortExpression, bool ascending = false)
        {
            var query = ascending
                ? context.Set<TEntity>().OrderBy(sortExpression)
                : context.Set<TEntity>().OrderByDescending(sortExpression);

            var itemsToSkip = (pageNumber - 1) * itemPerPage;
            var pageItems = await query
                .Skip(() => itemsToSkip)
                .Take(() => itemPerPage)
                .ToListAsync();

            return new PageViewModel<TViewModel>
            {
                Items = mapper.Map<IEnumerable<TViewModel>>(pageItems),
                Count = await query.CountAsync()
            };
        }
    }
}