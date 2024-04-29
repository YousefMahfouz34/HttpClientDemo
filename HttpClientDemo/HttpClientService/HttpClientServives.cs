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
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        }
        public async Task AddAsync(Post post)
        {
            //var postcreate = JsonSerializer.Serialize(post);
            //var requestContent = new StringContent(postcreate, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "xxxxxxxxxxxxxxxxxxxx");
            var response = await httpClient.PostAsJsonAsync<Post>("Posts", post);
           
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var res = await httpClient.DeleteAsync($"Posts/{id}");
            // Process response
            return res.IsSuccessStatusCode;

        }

        public async Task<List<Post>> GetAllAsync()
        {
            var response = await httpClient.GetAsync("Posts");
            response.EnsureSuccessStatusCode();
  
            var content = await response.Content.ReadFromJsonAsync<List<Post>>();
            // var posts = JsonSerializer.Deserialize<List<Post>>(content);
            return content;

        }

        public async Task<Post> GetByIdAsync(int id)
        {
            var response = await httpClient.GetAsync($"Posts/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadFromJsonAsync<Post>();
            return content;

            //var posts = JsonSerializer.Deserialize<Post>(content);
           // var post = posts.FirstOrDefault(p => p.id == id);
               // return posts;
        }

        public async Task<Post> UpdateAsync(Post post)
        {
            try
            {
                var response = await httpClient.PutAsJsonAsync<Post>($"Posts/{post.id}", post);
                response.EnsureSuccessStatusCode();
                var res = response.Content.ReadAsAsync<Post>();
                return post;    
            }
            catch (Exception ex) 
            {
                throw ex;   
            }

            

        }
    }
}
