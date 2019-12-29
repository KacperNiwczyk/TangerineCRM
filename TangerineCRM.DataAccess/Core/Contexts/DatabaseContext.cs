using System.Data.Entity;
using TangerineCRM.DataAccess.Core.Mapping;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.DataAccess.Core.Contexts
{
    public class DatabaseContext : DbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<Store> Stores { get; set; }
        DbSet<Agreement> Agreements { get; set; }
        DbSet<Appointment> Appointments { get; set; }
        DbSet<Contractor> Contractors { get; set; }
        DbSet<SalesRepresentative> SalesRepresentatives { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DatabaseContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMapping());
            modelBuilder.Configurations.Add(new AddressMapping());
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new StoreMapping());
            modelBuilder.Configurations.Add(new SalesRepresentativeMapping());
            modelBuilder.Configurations.Add(new ContractorMapping());
            modelBuilder.Configurations.Add(new AppointmentMapping());
            modelBuilder.Configurations.Add(new AgreementMapping());
        }
    }
}
