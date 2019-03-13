using AutoMapper;
using NewsPortal.Bootstrapper;
using NewsPortal.Common.Enums;
using NewsPortal.Common.Filters;
using NewsPortal.NewsFeedSources.Interfaces;
using NewsPortal.ServicesFacade.Concrete;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NewsPortal.Web.Controllers
{
    public class NewsPageController : Controller
    {
        private readonly IHabraHabrFetcher habraHabrFetcher;
        private readonly IInterfaxFetcher interfaxFetcher;

        private readonly IMapper mapper;
        private readonly INewsService newsService;

        public NewsPageController(IHabraHabrFetcher habraHabrFetcher, IInterfaxFetcher interfaxFetcher, 
            IMapper mapper, INewsService newsService)
        {
            this.habraHabrFetcher = habraHabrFetcher;
            this.interfaxFetcher = interfaxFetcher;
            this.mapper = mapper;
            this.newsService = newsService;
        }

        [HttpGet]
        public async Task<ActionResult> NewsPage(NewsFilter filter)
        {
            var model = await newsService.GetFilteredNews(filter);
            FillNewsPageViewBag(filter);
            return View(model);
        }

        private void FillNewsPageViewBag(NewsFilter filter)
        {
            ViewBag.PageNumber = filter.Page.Value;
            ViewBag.NumberOfItemsPerPage = filter.ItemsPerPage.Value;
            ViewBag.NewsSource = filter.Source?.ToString();
            ViewBag.NewsDate = filter.Sorting?.ToString();
        }
    }
}