using Microsoft.EntityFrameworkCore;

namespace Courses.Db
{
    public class CourseDbContext: DbContext
    {
        public DbSet<Course> Course { get; set; }
        public CourseDbContext(DbContextOptions options): base(options)
        {
            
        }
    }
}
