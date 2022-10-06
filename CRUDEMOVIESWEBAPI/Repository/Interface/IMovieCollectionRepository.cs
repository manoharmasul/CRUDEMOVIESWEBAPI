using CRUDEMOVIESWEBAPI.Model;

namespace CRUDEMOVIESWEBAPI.Repository.Interface
{
    public interface IMovieCollectionRepository
    {
        Task<int> AddMoviesCollection(Collection collection);   
    }
}
