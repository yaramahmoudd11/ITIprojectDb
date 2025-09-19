using ITIprojectDb.Models;
using Microsoft.EntityFrameworkCore;

namespace ITIprojectDb.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }    
        public DbSet<Address> Addresses { get; set; }

    }
}
