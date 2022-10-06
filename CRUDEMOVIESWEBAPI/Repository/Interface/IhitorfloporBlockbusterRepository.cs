using CRUDEMOVIESWEBAPI.Model;

namespace CRUDEMOVIESWEBAPI.Repository.Interface
{
    public interface IhitorfloporBlockbusterRepository
    {
        Task<int> AddNewHitOrFlopOrBlockbustrer(hitorfloporBlockbuster hitorflopor);
        Task<int> UpdateHitOrFlopOrBlockbustrer(hitorfloporBlockbuster hitorflopor);
    }
}
