using Blog.Common.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAL.DbModels
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Post> Posts { get; set; }
        public ApplicationContext()
        {
            
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DANATO-Z;Integrated security=False;Initial Catalog=Blog;Trusted_Connection=True;");
        }
    }
}
