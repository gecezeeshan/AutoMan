using AutoMapper;
using Courses.Db;
using Courses.Interface;
using Courses.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Courses.Provider
{
    public class CourseProvider : ICourseProvider
    {
        private readonly CourseDbContext courseDbContext;
        private readonly ILogger<CourseProvider> logger;
        private readonly IMapper mapper;

        public CourseProvider(CourseDbContext courseDbContext, ILogger<CourseProvider> logger, IMapper mapper)
        {
            this.courseDbContext = courseDbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

     
        public async Task<(bool IsSuccess, IEnumerable<Model.Course>? Courses, string? errorMessage)> GetCourseAsync()
        {
            try
            {
                var courses = await courseDbContext.Course.ToListAsync();
                if (courses != null && courses.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Course>, IEnumerable<Model.Course>>(courses);
                    return (true, result, null);
                }
                return (false, null, "Not found");

            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);

            }
        }

        public async Task<(bool IsSuccess, Model.Course Course, string? errorMessage)> GetCourseAsync(int courseId)
        {
            try
            {
                var courses = await courseDbContext.Course.Where(a => a.CourseId == courseId).FirstOrDefaultAsync();
                if (courses != null )
                {
                    var result = mapper.Map<Db.Course, Model.Course>(courses);
                    return (true, result, null);
                }
                return (false, null, "Not found");

            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);

            }
        }

        private void SeedData() {
            if (!courseDbContext.Course.Any()) {
                courseDbContext.Course.Add(new Db.Course { CourseId = 1, CourseName = "Algorithm", CourseDetail = "all basic algorithms" });
                courseDbContext.Course.Add(new Db.Course { CourseId = 2, CourseName = "Oops", CourseDetail = "all basic Oops" });
                courseDbContext.Course.Add(new Db.Course { CourseId = 3, CourseName = "C#", CourseDetail = "all basic c#" });
                courseDbContext.Course.Add(new Db.Course { CourseId = 4, CourseName = "Javscript", CourseDetail = "all basic js" });
            }
            courseDbContext.SaveChanges();
        }

      
    }
}
