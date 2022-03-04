using Lessons.Model;
namespace Lessons.Interface
{
    public interface ILessonProvider
    {
        Task<(bool IsSuccess, IEnumerable<Lesson>? Lessons, string? errorMessage)> GetLessonAsync();

        Task<(bool IsSuccess, IEnumerable<Lesson>? Lessons , string? errorMessage)> GetLessonAsync(int courseId);
    }
}
