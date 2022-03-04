using Search.Model;

namespace Search.Interface
{
    public interface ILessonService
    {
      Task<(bool IsSuccess, IEnumerable<Lesson> Lessons, string? errorMessage)> GetLessonAsync(int courseId);
        
    }
}
