using Microsoft.EntityFrameworkCore;

namespace Lessons.Db
{
    public class LessonDbContext: DbContext
    {
        public DbSet<Lesson> Lesson { get; set; }
        public LessonDbContext(DbContextOptions options): base(options)
        {
            
        }
    }
}
