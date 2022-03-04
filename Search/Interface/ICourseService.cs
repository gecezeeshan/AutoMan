using Search.Model;

namespace Search.Interface
{
    public interface ICourseService
    {
      Task<(bool IsSuccess, Course Courses, string? errorMessage)> GetCourseAsync(int courseId);
        Task<(bool IsSuccess, IEnumerable<Course> Courses, string? errorMessage)> GetCourseAsync();
    }
}
