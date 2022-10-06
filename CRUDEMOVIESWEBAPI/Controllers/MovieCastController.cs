using CRUDEMOVIESWEBAPI.Model;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDEMOVIESWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieCastController : ControllerBase
    {
        private readonly IMoviesCastRepository _moviesCastRepository;   
        public MovieCastController(IMoviesCastRepository moviesCastRepository)
        {
            _moviesCastRepository = moviesCastRepository;
        }
        [HttpPost("/AddMoviesCast")]
        public async Task<IActionResult> AddNewMoviesCast(movieCast cast,int aid,int mId,string rol,int cby)
        {
            var result=await _moviesCastRepository.AddMoviesCast(cast,aid,mId,rol,cby);
            return Ok(result);
        }
    }
}
