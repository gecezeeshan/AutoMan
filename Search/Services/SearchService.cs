using Search.Interface;
using Search.Model;
namespace Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly ICourseService courseService;
        private readonly ILessonService lessonService;

        public SearchService(ICourseService courseService, ILessonService lessonService)
        {
            this.courseService = courseService;
            this.lessonService = lessonService;
        }
        public async Task<(bool IsSuccess, dynamic SearchResult)> SearchAsync(int courseId)
        {

            var courseResult = await courseService.GetCourseAsync(courseId);
            var lessonResult = await lessonService.GetLessonAsync(courseId);

            if (courseResult.IsSuccess)
            {
                if(lessonResult.IsSuccess)
                courseResult.Courses.Lessons = lessonResult.Lessons.ToList();
                
                
                
                var result = new
                {
                    Course = courseResult.Courses

                };
                return (true,result);

            }
            return (true, null);

        }

        public async Task<(bool IsSuccess, dynamic SearchResult)> SearchAsync()
        {
            var courseResult = await courseService.GetCourseAsync();

            if (courseResult.IsSuccess)
            {
                foreach (var course in courseResult.Courses) {
                    var lessonResult = await lessonService.GetLessonAsync(course.CourseId);
                    if (lessonResult.IsSuccess)
                    {
                        course.Lessons = lessonResult.Lessons.ToList();
                    }

                }


                var result = new
                {
                    Course = courseResult.Courses
                };
                return (true, result);

            }
            return (true, null);
        }
    }
}
