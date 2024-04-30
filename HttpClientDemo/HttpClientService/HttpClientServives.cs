using HttpClientDemo.Domains;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace HttpClientDemo.HttpClientService
{
    public class HttpClientServives : IHttpClientServices
    {
        private readonly HttpClient httpClient;
        public HttpClientServives()
        {
            //https://localhost:7232/api/Posts/Delete?id=1
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7232/api/Posts/");
        }
        public async Task AddAsync(Post post)
        {
            //var postcreate = JsonSerializer.Serialize(post);
            //var requestContent = new StringContent(postcreate, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "xxxxxxxxxxxxxxxxxxxx");
            var response = await httpClient.PostAsJsonAsync<Post>("AddPost", post);
           
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var res = await httpClient.DeleteAsync($"Delete?id={id}");
            // Process response
            return res.IsSuccessStatusCode;

        }

        public async Task<List<Post>> GetAllAsync()
        {
            var response = await httpClient.GetAsync("GetAllPosts");
            response.EnsureSuccessStatusCode();
  
            var content = await response.Content.ReadFromJsonAsync<List<Post>>();
            // var posts = JsonSerializer.Deserialize<List<Post>>(content);
            return content;

        }

        public async Task<Post> GetByIdAsync(int id)
        {
            var response = await httpClient.GetAsync($"GetPostById?id={id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadFromJsonAsync<Post>();
            return content;

            //var posts = JsonSerializer.Deserialize<Post>(content);
           // var post = posts.FirstOrDefault(p => p.id == id);
               // return posts;
        }

        public async Task<bool> UpdateAsync(Post post)
        {
            
                var response = await httpClient.PutAsJsonAsync("Update", post); // No need to specify the type parameter
                response.EnsureSuccessStatusCode();
                    return response != null ? true : false;



        }
    }
}
