using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data.Domen
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Events> Events { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        :base(options)
        {
            
        }

       
    }
}