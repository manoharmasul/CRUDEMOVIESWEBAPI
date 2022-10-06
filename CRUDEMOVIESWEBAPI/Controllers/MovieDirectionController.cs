using CRUDEMOVIESWEBAPI.Model;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDEMOVIESWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieDirectionController : ControllerBase
    {
        private readonly ImovieDirectionRepository _movieDirectionRepository;   
        public MovieDirectionController(ImovieDirectionRepository movieDirectionRepository)
        {
            _movieDirectionRepository = movieDirectionRepository;
        }
        [HttpPost("/AddMoviesDirection")]
        public async Task<IActionResult> AddMovieDirection(movieDirection movieDirection,int mId,int dId,int cby)
        {
            var result=await _movieDirectionRepository.AddmovieDirection(movieDirection,mId,dId,cby);   
            return Ok(result);

        }
        [HttpGet("GetAllMovieDirection")]
        public async Task<IActionResult> GetAllMoviesDirection()
        {
            var result = await _movieDirectionRepository.GetAllMoviesDirection();
            return Ok(result);  

        }
    }
}
