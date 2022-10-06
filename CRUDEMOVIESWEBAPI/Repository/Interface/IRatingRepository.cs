using CRUDEMOVIESWEBAPI.Model;

namespace CRUDEMOVIESWEBAPI.Repository.Interface
{
    public interface IRatingRepository
    {
        Task<int> AddRating(Rating rrating);
        Task<int> UpdateRating(Rating rrating);  
    }
}
