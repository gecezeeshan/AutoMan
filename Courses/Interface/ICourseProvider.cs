using Courses.Model;
namespace Courses.Interface
{
    public interface ICourseProvider
    {
        Task<(bool IsSuccess, IEnumerable<Course> Courses, string? errorMessage)> GetCourseAsync();

        Task<(bool IsSuccess, Course Course, string? errorMessage)> GetCourseAsync(int courseId);
    }
}
