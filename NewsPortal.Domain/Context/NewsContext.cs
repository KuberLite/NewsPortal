using NewsPortal.Domain.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NewsPortal.Domain.Context
{
    class NewsContext : DbContext
    {
        public NewsContext() : base("NewsContext")
        {

        }

        public DbSet<News> Newss { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}