using CRUDEMOVIESWEBAPI.Model;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDEMOVIESWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository _RetingRepo;
        public RatingController(IRatingRepository retingRepo)
        {
            _RetingRepo = retingRepo;
        }
        [HttpPost]
        public async Task<IActionResult> AddNewRating(Rating rating)
        {
            var result=await _RetingRepo.AddRating(rating); 
            return Ok(result);  

        }
        
    }
}
