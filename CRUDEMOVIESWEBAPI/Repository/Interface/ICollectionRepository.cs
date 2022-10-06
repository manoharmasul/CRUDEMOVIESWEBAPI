using CRUDEMOVIESWEBAPI.Model;

namespace CRUDEMOVIESWEBAPI.Repository.Interface
{
    public interface ICollectionRepository
    {
        Task<int> AddMoviesCollection(Collection collection);   
    }
}
