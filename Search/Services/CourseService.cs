using Microsoft.Extensions.Logging;
using Search.Interface;
using Search.Model;
using System.Text.Json;

namespace Courses.Services
{
    public class CourseService : ICourseService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<CourseService> logger;

        public CourseService(IHttpClientFactory httpClientFactory, ILogger<CourseService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }
        public async Task<(bool IsSuccess, IEnumerable<Course> Courses, string? errorMessage)> GetCourseAsync()
        {

            try
            {
                var client = httpClientFactory.CreateClient("CourseService");
                var response = await client.GetAsync($"api/courses");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();//get content in byte array
                   var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var courses = JsonSerializer.Deserialize<IEnumerable<Course>>(content,options);
                    return (true, courses, null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.Message);
                return (false, null, ex.Message);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Course Courses, string? errorMessage)> GetCourseAsync(int courseId)
        {

            try
            {
                var client = httpClientFactory.CreateClient("CourseService");
                var response = await client.GetAsync($"api/courses/{courseId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();//get content in byte array
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var courses = JsonSerializer.Deserialize<Course>(content,options);
                    return (true, courses, null);

                    
                }
                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.Message);
                return (false, null, ex.Message);
                throw;
            }
        }

      
    }
}
