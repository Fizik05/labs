using Microsoft.EntityFrameworkCore;
using Third_laba.Models;

namespace Third_laba.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<AchievementCat> AchievementCats { get; set; }
        public DbSet<Third_laba.Models.AchievementCat>? AchievementCat { get; set; }
    }
}
