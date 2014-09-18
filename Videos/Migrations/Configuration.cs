namespace Videos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Videos.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Videos.Models.VideoDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Videos.Models.VideoDB context)
        {
            //This is a lambda expression
            context.Videos.AddOrUpdate(v => v.Title,
                new Video() { Title = "MVC4", Length = 120 },
                new Video() { Title = "LINQ", Length = 200 }
                );
        }
    }
}
