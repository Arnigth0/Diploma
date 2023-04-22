using Diploma.Model;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Repositories
{
    class DataBaseContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientCharacteristics> ClientCharacteristics { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Prerequisite> Prerequisites { get; set; }

        public DataBaseContext()
        {
            //Использовался единожды для создания таблиц и отношений
            //Не использовать!
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
                Server=(localdb)\MSSQLLocalDB;
                Database=Diploma;
                Trusted_Connection=True;"
            );
        }
    }
}
