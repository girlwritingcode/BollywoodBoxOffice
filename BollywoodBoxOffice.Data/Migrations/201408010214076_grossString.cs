namespace BollywoodBoxOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class grossString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Gross", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Gross", c => c.String());
        }
    }
}
