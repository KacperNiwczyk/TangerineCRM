using System.Data.Entity;
using TangerineCRM.Entities.Base;


namespace TangerineCRM.DataAccess.Core.Contexts
{
    public class DatabaseContext : DbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Store> Stores { get; set; }
        DbSet<Agreement> Agreements { get; set; }
        DbSet<Appointment> Appointments { get; set; }
        DbSet<Contractor> Contractors { get; set; }
        DbSet<SalesRepresentative> SalesRepresentatives { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DatabaseContext>());
        }
    }
}
