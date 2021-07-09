using Microsoft.EntityFrameworkCore;

namespace Exam.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        // the "Users" table name will come from the DbSet variable name
        public DbSet<User> Users { get; set; }
        public DbSet<Activitym> Activityms { get; set; }
        public DbSet<Join> Joins { get; set; }
    }
}