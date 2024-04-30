using HttpClientDemo.Domains;

namespace HttpClientDemo.HttpClientService
{
    public interface IHttpClientServices
    {
        Task<List<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(int id);
        Task AddAsync(Post post);
        Task<bool>UpdateAsync(Post post);
        Task<bool>DeleteAsync(int id);
      
    }
}
