using Microsoft.EntityFrameworkCore;

namespace TaskApp.Models
{
    public class MyAppDbContext:DbContext
    {
        
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
        {

        }
        public DbSet<TaskGroup> TaskGroups { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }

        public DbSet<UserCollection> UserCollections { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.UserSeed();
        }
    }
}
