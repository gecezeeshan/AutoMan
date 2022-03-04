using Lessons.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Lessons.Controllers
{
    [ApiController]
    [Route("api/Lessons")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonProvider LessonProvider;

        public LessonController(ILessonProvider LessonProvider)
        {
            this.LessonProvider = LessonProvider;
        }
        [HttpGet]
        public async Task<IActionResult> GetLessonAsync()
        {
           var result = await LessonProvider.GetLessonAsync();
            if (result.IsSuccess) {
                return Ok(result.Lessons);
            }
            return NotFound();
        }


        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetLessonAsync(int courseId)
        {
            var result = await LessonProvider.GetLessonAsync(courseId);
            if (result.IsSuccess)
            {
                return Ok(result.Lessons);
            }
            return NotFound();
        }
    }
}
