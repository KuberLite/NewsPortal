namespace NewsPortal.Domain.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Title = c.String(nullable: false, maxLength: 128),
                        PubDate = c.DateTime(nullable: false),
                        Link = c.String(),
                        Guid = c.String(),
                        Description = c.String(),
                        Creator = c.String(),
                    })
                .PrimaryKey(t => new { t.Title, t.PubDate });
        }
        
        public override void Down()
        {
            DropTable("dbo.News");
        }
    }
}