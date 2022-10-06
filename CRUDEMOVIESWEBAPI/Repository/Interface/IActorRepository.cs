using CRUDEMOVIESWEBAPI.Model;

namespace CRUDEMOVIESWEBAPI.Repository.Interface
{
    
    public interface IActorRepository
    {
        Task<int> AddNewActor(Actor actor);

        Task<int> UpdateActor(Actor actor);
        Task<int> DeleteActor(int id);
        Task<List<Actor>> GetAllActors();   
    }
}
