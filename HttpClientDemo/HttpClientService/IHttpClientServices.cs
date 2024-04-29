using HttpClientDemo.Domains;

namespace HttpClientDemo.HttpClientService
{
    public interface IHttpClientServices
    {
        Task<List<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(int id);
        Task AddAsync(Post post);
        Task<Post>UpdateAsync(Post post);
        Task<bool>DeleteAsync(int id);
      
    }
}
