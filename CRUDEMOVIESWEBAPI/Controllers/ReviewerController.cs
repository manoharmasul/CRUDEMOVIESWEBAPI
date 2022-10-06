using CRUDEMOVIESWEBAPI.Model;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDEMOVIESWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : ControllerBase
    {
        private readonly IReviwerRepository _reviwerRepository;
        public ReviewerController(IReviwerRepository reviwerRepository)
        {
            _reviwerRepository = reviwerRepository;
        }
        [HttpPost("/Add New Review")]
        public async Task<IActionResult> AddNewReview(Reviewer reviewer)
        {
            var result=await _reviwerRepository.AddReview(reviewer);  
            if(result==0)
            {
                return StatusCode(500, "please enter correct MovieId");

            }

            return StatusCode(200,"Response Submitted Successfully"+result);

        }
        [HttpPut("update Review")]
        public async Task<IActionResult> UpdateReview(Reviewer reviewer)
        {
            var result = await _reviwerRepository.UpdateReview(reviewer);
           
            return Ok(result);
        }
    }
}
