using AutoMapper;
using NewsPortal.Domain.Context;
using NewsPortal.Domain.Entities;
using NewsPortal.Services.Base;
using NewsPortal.ServicesFacade.Concrete;
using NewsPortal.ViewModel.Concrete;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Services.Concrete
{
    public class NewsService : Service<News, NewsViewModel>, INewsService
    {
        protected readonly NewsContext _context;

        public NewsService(NewsContext context, IMapper mapper) : base(context, mapper)
        {
        }

        
    }
}
