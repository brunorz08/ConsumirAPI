using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ConsumoAPI.Controllers;
using ConsumoAPI.Models;

namespace ConsumoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly API _apiService;
        private Random random;
        int numeroRandom;

        public PostController(API apiService)
        {
            _apiService = apiService;
            random = new Random();
        }

        //Obtener todos los posts
        [HttpGet("all")]
        public async Task<ActionResult<List<Post>>> GetAll()
        {
            var posts = await _apiService.SolicitudHTTP<List<Post>>("https://jsonplaceholder.typicode.com/posts");
            return posts;
        }

        //Obtener post random
        [HttpGet("random")]
        public async Task<ActionResult<Post>> GetRandom()
        {
            numeroRandom = random.Next(0, 101);
            var post = await _apiService.SolicitudHTTP<Post>($"https://jsonplaceholder.typicode.com/posts/{numeroRandom}");
            return post;
        }

        //Obtener post por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostById(int id)
        {

            var post = await _apiService.SolicitudHTTP<Post>($"https://jsonplaceholder.typicode.com/posts/{id}");

            return post;
        }



    }
}
