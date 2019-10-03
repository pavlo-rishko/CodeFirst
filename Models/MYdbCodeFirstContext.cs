using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class MYdbCodeFirstContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Dormitory> Dormitories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WIN-BKMNAK88A69\SQLEXPRESS;Database=MYdbCodeFirst;Trusted_Connection=True");
        }

        private MYdbCodeFirstContext()
        {

        }
        public MYdbCodeFirstContext(DbContextOptions<MYdbCodeFirstContext> options):base(options)
        {

        }
    }    
}

