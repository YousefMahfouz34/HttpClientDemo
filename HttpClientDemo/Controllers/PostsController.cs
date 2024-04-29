using HttpClientDemo.Domains;
using HttpClientDemo.HttpClientService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IHttpClientServices _httpClientService;
        public PostsController(IHttpClientServices httpClientServices)
        {
          _httpClientService = httpClientServices;
            
        }
        [HttpGet]
        [Route("GetAllPosts")]

        public async Task< IActionResult> Get() 
        {
            var res= await _httpClientService.GetAllAsync();
            return Ok(res);
        }
        [HttpGet]
        [Route("GetPostById")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var res = await _httpClientService.GetByIdAsync(id);
            return Ok(res);
        }
        [HttpPost]
        [Route("AddPost")]

        public async Task<IActionResult> Create(Post post)
        {
            try
            {
                await _httpClientService.AddAsync(post);
                return Ok("Added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
        [HttpPut]
        [Route("Update")]

        public async Task<IActionResult> Update(Post post)
        {
            try
            {
                await _httpClientService.UpdateAsync(post);
                return Ok("updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _httpClientService.DeleteAsync(id);
                return Ok(res);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
