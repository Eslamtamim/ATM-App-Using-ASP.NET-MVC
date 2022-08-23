using Microsoft.EntityFrameworkCore;

namespace mvcTest1.Models
{
    public class AccountDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(@"Data Source=HAYDRA\SQLEXPRESS;Initial Catalog=AspAtmData;Integrated Security=True;");

        public DbSet<Account> Accounts { get; set; }

    }
    
}
