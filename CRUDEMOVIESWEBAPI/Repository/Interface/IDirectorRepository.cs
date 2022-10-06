using CRUDEMOVIESWEBAPI.Model;
using Microsoft.AspNetCore.Components.Forms;

namespace CRUDEMOVIESWEBAPI.Repository.Interface
{
    public interface IDirectorRepository
    {
        Task<int> AddDirector(Director director);
        Task<int> UpdateDirector(int dId,int noofMovies);
        Task<List<Director>> GetAllDirectors(); 
    }
}
