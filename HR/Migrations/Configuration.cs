namespace HR.Migrations
{
    using HR.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HR.Model_HR>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HR.Model_HR context)
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



            //context.Clients.AddOrUpdate(
            //  c => c.Id,
            //  new Client { Name = "Nabil", Details = "None", Address = "Tanger Braness", ContactNumber = "+212661425312", ContactEmail = "NabileComp@gmail.com", CompanyUrl = "www.NabilExpress.com", Status = "None", FirstContact = DateTime.Now },
            //  new Client { Name = "Mouad", Details = "None", Address = "Tanger bokhalef", ContactNumber = "+212667225333", ContactEmail = "MouadCompany@gmail.com", CompanyUrl = "www.MouadExpress.com", Status = "None", FirstContact = DateTime.Now }
            //);


        }
    }
}
