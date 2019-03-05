using AutoMapper;
using NewsPortal.Domain.Entities;
using NewsPortal.FetcherFacade.Models;
using NewsPortal.ViewModel.Concrete;

namespace NewsPortal.ViewModel.MappingProfiles
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<News, NewsViewModel>()
                .ReverseMap();

            CreateMap<NewsFromXmlModel, NewsViewModel>();
        }
    }
}
