using CRUDEMOVIESWEBAPI.Model;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace CRUDEMOVIESWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        [HttpPost("/AddNewMovies")]
        public async Task<IActionResult> AddNewMovies(Movie movies,int aid )
        {
            var result=await _movieRepository.AddNewMovie( movies,aid );
            return StatusCode(500, "Movies inserted Successfully with Id" + result);
        }
        [HttpGet("/GetAllMovies")]
        public async Task<IActionResult> GetAllMovies()
        {
            var result = await _movieRepository.GetAllMovies();
            return Ok(result);
        }
        [HttpPost("AddNewRealeasedMovie")]
        public async Task<IActionResult> AddNewRealeased(MovieTicketPrice mtprice)
        {
            var result=await _movieRepository.AddNewRealeaseList(mtprice);
            if(result ==0)
            {
                return StatusCode(500, "movie not exist");
            }
    
            else
                return StatusCode(200, "movie inserted successfully");



        }

    }
}
