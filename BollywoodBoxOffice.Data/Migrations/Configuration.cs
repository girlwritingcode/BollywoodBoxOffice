namespace BollywoodBoxOffice.Data.Migrations
{
    using BollywoodBoxOffice.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BollywoodBoxOffice.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BollywoodBoxOffice.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Movies.AddOrUpdate(m => m.Name,
                new Movie("Dhoom 3", "http://upload.wikimedia.org/wikipedia/en/f/f1/Dhoom_3_Film_Poster.jpg", 90, 2013, "Yash Raj Films", "Vijay Krishna Acharya"),
                new Movie("Chennai Express", "http://upload.wikimedia.org/wikipedia/en/1/1b/Chennai_Express.jpg", 78, 2013, "Red Chillies Entertainment", "Rohit Shetty"),
                new Movie("Krrish 3", "http://upload.wikimedia.org/wikipedia/en/6/67/Krrish_3_Poster.jpg", 50, 2013, "Filmkraft Productions", "Rakesh Roshan")
                );
        }
    }
}
