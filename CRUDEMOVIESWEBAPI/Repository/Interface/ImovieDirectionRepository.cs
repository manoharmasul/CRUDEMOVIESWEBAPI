using CRUDEMOVIESWEBAPI.Model;

namespace CRUDEMOVIESWEBAPI.Repository.Interface
{
    public interface ImovieDirectionRepository
    {
        Task<int> AddmovieDirection(movieDirection moviedirection,int mId,int dId,int cby);
        Task<int> UpdatemovieDirection(movieDirection moviedirection);  
        Task DeletemovieDirection(int id );
        Task<List<movieDirection>> GetAllMoviesDirection();
    }
}
