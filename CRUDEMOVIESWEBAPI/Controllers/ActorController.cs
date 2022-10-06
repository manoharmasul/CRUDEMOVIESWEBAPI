using CRUDEMOVIESWEBAPI.Model;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDEMOVIESWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository _actorRepo;
        public ActorController(IActorRepository actorRepo)
        {
            _actorRepo = actorRepo;
        }
        [HttpPost("/Add New Actor")]
        public async Task<IActionResult> AddNewActor(Actor actor)
        {
            var result=await _actorRepo.AddNewActor(actor);
            if(result==-1)
            {
                return StatusCode(500, "Actor with name" + actor.aName + "already present movie and cast Added successfully");
            }
            else
            {
                return StatusCode(200,"Actor Successfully Aded with Id"+ result); 
            }
            
        }
        [HttpPut("/update actor")]
        public async Task<IActionResult> UpdateActor(Actor actor)
        {
            var result=await _actorRepo.UpdateActor(actor);

            return Ok(result);
        }
        [HttpGet("/GetAllActors")]
        public async Task<IActionResult> GetAllActirs()
        {
            var result = await _actorRepo.GetAllActors();
            return Ok(result);
        }
    }
}
