using CRUDEMOVIESWEBAPI.Model;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDEMOVIESWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionRepository _collectionRepository;   
        public CollectionController(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }
        [HttpPost("/AddCollections")]
        public async Task<IActionResult> AddNewCollection(Collection collection)
        {
            var result=await _collectionRepository.AddMoviesCollection(collection);

            if (result >= 1)
            {
                return StatusCode(200, "Data Added Successfully");
            }
            else if (result == -1)
            {
                return StatusCode(500, "Please Enter Correct MovieId");
            }
            else if (result == -2)
            {

                return StatusCode(200, "movie with collection updated and HitOrFlopOrBlockBusteris is updated");

            }
            else

                return StatusCode(200, "HitFlopOrBlockbuster Inserted Successfully");
            
        }
    }
}
