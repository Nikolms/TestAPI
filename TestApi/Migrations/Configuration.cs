namespace TestApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestApi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestApi.Models.TestApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestApi.Models.TestApiContext context)
        {

            context.Authors.AddOrUpdate(
                x => x.ID,
                new Author() {ID = 1, Name="Tuntematon Kirjailija" },
                new Author() {ID = 2, Name="Kaikkien Suosikki" },
                new Author() {ID = 3, Name="Joku Tavis" }
                );

            context.Books.AddOrUpdate(
                x => x.ID,
                new Book() {ID = 1, Title= "Eka Kirja", Genre="Adventure", Year = 1999, AuthorID = 1 },
                new Book() {ID = 2, Title= "Apua!", Genre = "Horror", Year = 2002, AuthorID = 2},
                new Book() { ID = 2, Title = "Apua2!", Genre = "Horror", Year = 2004, AuthorID = 2 },
                new Book() { ID = 2, Title = "Apua3!", Genre = "Horror", Year = 2006, AuthorID = 2 },
                new Book() {ID = 3, Title= "Mun Tarina", Genre = "Self Bio", Year = 2014, AuthorID = 3}
                );
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
        }
    }
}
