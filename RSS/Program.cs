using AutoMapper;
using NewsPortal.Bootstrapper;
using NewsPortal.Domain.Context;
using NewsPortal.Domain.Entities;
using NewsPortal.FetcherFacade.Models;
using NewsPortal.NewsFeedSources;
using NewsPortal.NewsFeedSources.Interfaces;
using NewsPortal.ServicesFacade.Concrete;
using NewsPortal.ViewModel.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NewsPortal.ConsoleSeed
{
    public class Program
    {
        private static readonly IDependencyResolver dependencyResolver;

        private static readonly IHabraHabrFetcher habraHabrFetcher;
        private static readonly IInterfaxFetcher interfaxFetcher;

        private static readonly IMapper mapper;
        private static readonly INewsService newsService;

        static Program()
        {
            dependencyResolver = AppBootstrapper.GetDependencyResolver();

            habraHabrFetcher = dependencyResolver.GetService<IHabraHabrFetcher>();
            interfaxFetcher = dependencyResolver.GetService<IInterfaxFetcher>();

            mapper = dependencyResolver.GetService<IMapper>();
            newsService = dependencyResolver.GetService<INewsService>();
        }

        static void Main(string[] args)
        {
            Task.Run(async () => await ProcessMain())
                .Wait();
            Console.WriteLine("Succesfully");
        }

        private static async Task ProcessMain()
        {
            var habrFeed = await habraHabrFetcher.GetNewsFeed();
            await SeedNews(habrFeed, habraHabrFetcher.FetchUri);

            var interfaxFeed = await interfaxFetcher.GetNewsFeed();
            await SeedNews(interfaxFeed, interfaxFetcher.FetchUri);
        }

        private static async Task SeedNews(List<NewsFromXmlModel> newsFeed, string source)
        {
            var newsModels = mapper.Map<IEnumerable<NewsViewModel>>(newsFeed);
            var savedNewsCount = await newsService.AddNewsFeed(newsModels);

            Console.WriteLine($"Fetched {savedNewsCount} new records from source {source}");
        }
    }
}