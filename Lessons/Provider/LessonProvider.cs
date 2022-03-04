using AutoMapper;
using Lessons.Db;
using Lessons.Interface;
using Lessons.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Lessons.Provider
{
    public class LessonProvider : ILessonProvider
    {
        private readonly LessonDbContext LessonDbContext;
        private readonly ILogger<LessonProvider> logger;
        private readonly IMapper mapper;

        public LessonProvider(LessonDbContext LessonDbContext, ILogger<LessonProvider> logger, IMapper mapper)
        {
            this.LessonDbContext = LessonDbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }
     
        public async Task<(bool IsSuccess, IEnumerable<Model.Lesson>? Lessons, string? errorMessage)> GetLessonAsync()
        {
            try
            {
                var Lessons = await LessonDbContext.Lesson.ToListAsync();
                if (Lessons != null && Lessons.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Lesson>, IEnumerable<Model.Lesson>>(Lessons);
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

        public async Task<(bool IsSuccess, IEnumerable<Model.Lesson>? Lessons, string? errorMessage)> GetLessonAsync(int courseId)
        {
            try
            {
                var Lessons = await LessonDbContext.Lesson.Where(a => a.CourseId == courseId).ToListAsync();
                if (Lessons != null && Lessons.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Lesson>, IEnumerable<Model.Lesson>>(Lessons);
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
            if (!LessonDbContext.Lesson.Any()) {
                LessonDbContext.Lesson.Add(new Db.Lesson { LessonId = 1, CourseId = 1, LessonName = "Algorithm", LessonDetail = "all basic algorithms" });
                LessonDbContext.Lesson.Add(new Db.Lesson { LessonId = 2, CourseId = 1, LessonName = "Oops", LessonDetail = "all basic Oops" });
                LessonDbContext.Lesson.Add(new Db.Lesson { LessonId = 3, CourseId = 2, LessonName = "C#", LessonDetail = "all basic c#" });
                LessonDbContext.Lesson.Add(new Db.Lesson { LessonId = 4, CourseId = 3, LessonName = "Javscript", LessonDetail = "all basic js" });
            }
            LessonDbContext.SaveChanges();
        }

      
    }
}
