namespace Search.Interface
{
    public interface ISearchService
    {
        Task<(bool IsSuccess, dynamic SearchResult)> SearchAsync(int courseId);

        Task<(bool IsSuccess, dynamic SearchResult)> SearchAsync();
    }
}
