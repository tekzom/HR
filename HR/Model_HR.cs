namespace HR
{
    using HRuwp.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model_HR : DbContext
    {
        // Your context has been configured to use a 'Model_HR' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'HR.Model_HR' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model_HR' 
        // connection string in the application configuration file.
        public Model_HR()
            : base("name=Model_HR")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<Departement> Departements { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Leaves> Leaves { get; set; }
        public virtual DbSet<Suspension> Suspensions { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }



    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}