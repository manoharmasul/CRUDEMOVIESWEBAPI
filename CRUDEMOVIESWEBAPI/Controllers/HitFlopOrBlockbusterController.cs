using CRUDEMOVIESWEBAPI.Model;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDEMOVIESWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HitFlopOrBlockbusterController : ControllerBase
    {
        private readonly IhitorfloporBlockbusterRepository _hitorfloporBlockbusterRepository;   
        public HitFlopOrBlockbusterController(IhitorfloporBlockbusterRepository hitorfloporBlockbusterRepository)
        {
            _hitorfloporBlockbusterRepository = hitorfloporBlockbusterRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddNewHitFlopOrblockbuster(hitorfloporBlockbuster hitorflopor)
        {
            var result = await _hitorfloporBlockbusterRepository.AddNewHitOrFlopOrBlockbustrer(hitorflopor);
            return Ok(result);
        }
        [HttpGet("GetHitFlopBlockbuster")]
        public async Task<IActionResult> GetHitFlopBlock(int id)
        {
            var result = await _hitorfloporBlockbusterRepository.GetHitorflopor(id);
            return Ok(result);
        }
    }
}
