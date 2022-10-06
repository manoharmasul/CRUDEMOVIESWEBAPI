using CRUDEMOVIESWEBAPI.Context;
using CRUDEMOVIESWEBAPI.Model;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using Dapper;

namespace CRUDEMOVIESWEBAPI.Repository
{
    public class MoviesCastRepository: IMoviesCastRepository
    {
        private readonly DapperContext _dapperContext;  
        public MoviesCastRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }   
     

        public async Task<int> AddMoviesCast(movieCast moviesCast,int aid,int mId,string rol,int cby)
        {
            
            var query = "insert into tblmovieCast (aId,mId,rol,createdBy,isDeleted) values(@aId,@mId,@rol,@createdBy,0)";
            using (var connection = _dapperContext.CreateConnection())
            {
                moviesCast.aId = aid;
                moviesCast.mId = mId;
                moviesCast.createdBy = cby;
                moviesCast.rol= rol;    
                var result = await connection.ExecuteAsync(query, moviesCast);
                return result;
            }
        }

        public Task<List<movieCast>> GetAllMovieCast()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateMoviesCast(movieCast moviesCast)
        {
            throw new NotImplementedException();
        }
    }
}
