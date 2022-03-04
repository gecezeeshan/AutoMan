using Microsoft.Extensions.Logging;
using Search.Interface;
using Search.Model;
using System.Text.Json;

namespace Lessons.Services
{
    public class LessonService : ILessonService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<LessonService> logger;

        public LessonService(IHttpClientFactory httpClientFactory, ILogger<LessonService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }
        
        public async Task<(bool IsSuccess, IEnumerable<Lesson> Lessons, string? errorMessage)> GetLessonAsync(int courseId)
        {

            try
            {
                var client = httpClientFactory.CreateClient("LessonService");
                var response = await client.GetAsync($"api/Lessons/{courseId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();//get content in byte array
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var Lessons = JsonSerializer.Deserialize<IEnumerable<Lesson>>(content,options);
                    return (true, Lessons, null);

                    
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
