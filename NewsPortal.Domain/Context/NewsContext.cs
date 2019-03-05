using NewsPortal.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NewsPortal.Domain.Context
{
    public class NewsContext : DbContext
    {
        public NewsContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}