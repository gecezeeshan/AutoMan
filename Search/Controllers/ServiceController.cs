using Microsoft.AspNetCore.Mvc;
using Search.Interface;
using Search.Model;

namespace Search.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class ServiceController : ControllerBase
    {
        private readonly ISearchService searchService;

        public ServiceController(ISearchService searchService)
        {
            this.searchService = searchService;
        }
        [HttpPost]
        public async Task<IActionResult> SearchAsync(SearchTerm searchTerm) {
           var result =  await searchService.SearchAsync(searchTerm.CourseId);
            
            if (result.IsSuccess)
            {
                return Ok(result.SearchResult);

            }
            return NotFound();
        }

        [HttpPost("GetCourseInfo")]
        public async Task<IActionResult> GetCourseInfo()
        {
            var result = await searchService.SearchAsync();

            if (result.IsSuccess)
            {
                return Ok(result.SearchResult);

            }
            return NotFound();
        }

    }
}
