using Courses.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Courses.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseProvider courseProvider;

        public CourseController(ICourseProvider courseProvider)
        {
            this.courseProvider = courseProvider;
        }
        [HttpGet]
        public async Task<IActionResult> GetCourseAsync()
        {
           var result = await courseProvider.GetCourseAsync();
            if (result.IsSuccess) {
                return Ok(result.Courses);
            }
            return NotFound();
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetCourseAsync(int courseId)
        {
            var result = await courseProvider.GetCourseAsync(courseId);
            if (result.IsSuccess)
            {
                return Ok(result.Course);
            }
            return NotFound();
        }
    }
}
