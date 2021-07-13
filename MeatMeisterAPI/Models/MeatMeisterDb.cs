using System;
using System.Data.Entity;
using System.Linq;

namespace MeatMeisterAPI.Models
{
    public class MeatMeisterDb : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MeatMeisterAPI.Models.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public MeatMeisterDb()
            : base("name=MeatMeisterDb")
        {
        }

        public DbSet<DeerElkOrder> DeerElkOrders { get; set; }

        public DbSet<HogOrder> HogOrders { get; set; }

        public DbSet<SheepOrder> SheepOrders { get; set; }

        public DbSet<BeefOrder> BeefOrders { get; set; }

        public DbSet<MeatOrder> MeatOrders { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}