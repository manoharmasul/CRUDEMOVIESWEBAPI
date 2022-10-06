using CRUDEMOVIESWEBAPI.Model;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDEMOVIESWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorRepository _directorRepo;
        public DirectorController(IDirectorRepository directorRepo)
        {
            _directorRepo = directorRepo;
        }

        [HttpPost("/Add New Director")]
        public async Task<IActionResult> AddNewDirector(Director director)
        {
            var result=await _directorRepo.AddDirector(director);
            return Ok(result);
        }
    }
}
