using AutoMapper;
using NewsPortal.Bootstrapper;
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

        public async Task<ActionResult> NewsPage(int? page, int? itemsPerPage)
        {
            ViewData["Page"] = page;
            var pageNumber = page ?? 1;
            var numberOfItemsPerPage = 
                itemsPerPage ?? Convert.ToInt32(ConfigurationManager.AppSettings["DefaultNumberOfItemsPerPage"]);

            var model = await newsService.GetPage(
                pageNumber, numberOfItemsPerPage, news => news.PubDate);

            ViewBag.PageNumber = pageNumber;
            ViewBag.NumberOfItemsPerPage = numberOfItemsPerPage;

            return View(model);
        }
    }
}