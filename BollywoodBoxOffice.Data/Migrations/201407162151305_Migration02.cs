namespace BollywoodBoxOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        URL = c.String(),
                        Gross = c.String(),
                        Year = c.Int(nullable: false),
                        Studio = c.String(),
                        Director = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
