using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Financial_Stock.Model
{
    public class Context :IdentityDbContext<ApplicationUser>
    {
        
        public Context()
        {

        }
        
        public Context (DbContextOptions <Context>optios ) : base(optios)
        {

        }

        public DbSet<Orders> orders { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<OrderAuditLog> Log { get; set; }
        public DbSet<OrderStatus> status{ get; set; }
        public DbSet<Stock> stock { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data source=.;Initial catalog=Ecommrec Stock;Integrated security=true");
            base.OnConfiguring(optionsBuilder);
        }






    }
}
