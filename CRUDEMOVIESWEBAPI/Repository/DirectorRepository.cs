using CRUDEMOVIESWEBAPI.Context;
using CRUDEMOVIESWEBAPI.Model;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace CRUDEMOVIESWEBAPI.Repository
{
    public class DirectorRepository: IDirectorRepository
    {
        private readonly DapperContext _context;
         public DirectorRepository(DapperContext context)
        {
            _context = context; 
        }

        public  async Task<int> AddDirector(Director director)
        {
            //dId,dName,noofMovies,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted

            var query = "insert into tblDirector(dName,noofMovies,createdBy,isDeleted) values(@dName,@noofMovies,@createdBy,0)";
            using(var connection= _context.CreateConnection())
            {
                var result=await connection.ExecuteAsync(query,director);
                return result;  
            }
        }

      
        public Task<List<Director>> GetAllDirectors()
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateDirector(int dId,int noofMovies)
        {
            using (var connection = _context.CreateConnection())
            {
               var result= await connection.ExecuteAsync("update tblDirector set noofMovies=@noofMovies where dId=@dId", new { dId = dId, noofMovies=noofMovies });
                return result;  
            }
        }
    }
}
