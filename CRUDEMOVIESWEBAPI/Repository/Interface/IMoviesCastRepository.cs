using CRUDEMOVIESWEBAPI.Model;

namespace CRUDEMOVIESWEBAPI.Repository.Interface
{
    public interface IMoviesCastRepository
    {
        Task<int> AddMoviesCast(movieCast moviesCast,int aId, int mId,string rol,int cby); 
        Task<int> UpdateMoviesCast(movieCast moviesCast);
        Task<List<movieCast>> GetAllMovieCast();
    }
}
