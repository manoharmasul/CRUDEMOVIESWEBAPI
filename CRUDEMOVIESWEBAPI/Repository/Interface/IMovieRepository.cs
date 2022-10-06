using CRUDEMOVIESWEBAPI.Model;

namespace CRUDEMOVIESWEBAPI.Repository.Interface
{
    public interface IMovieRepository
    {
        Task<int> AddNewMovie(Movie movies,int res);
        Task<int> UpdateMovies(Movie movies);
        Task<int> DeleteMovies(int id);
        Task<List<Movie>> GetAllMovies();
    }
}
