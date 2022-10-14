using CRUDEMOVIESWEBAPI.Context;
using CRUDEMOVIESWEBAPI.Model;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace CRUDEMOVIESWEBAPI.Repository
{
    public class MovieRepository : IMovieRepository
    {
        Director dr = new Director();
        private readonly IDirectorRepository _directorRepo;
        movieDirection md = new movieDirection();
        private readonly ImovieDirectionRepository _directionRepository;  
        movieCast mc=new movieCast();
        private readonly IMoviesCastRepository _movieCastRepo;
        private readonly DapperContext _context;

        public MovieRepository(DapperContext context,IMoviesCastRepository moviecastRepo,ImovieDirectionRepository movieDirectoin, IDirectorRepository direpo)
        {
            _context = context; 
            _movieCastRepo = moviecastRepo;
            _directionRepository=movieDirectoin;
            _directorRepo = direpo; 
        }
        public async Task<int> AddNewMovie(Movie movies, int res)
        {
            var ret = 0;
            //mId,mTitle,mBudget,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted
            var query = "insert into tblMovie (mTitle,mBudget,createdBy,isDeleted) values(@mTitle,@mBudget,@createdBy,0);SELECT CAST(SCOPE_IDENTITY() as int)";
            using (var connection=_context.CreateConnection())
            {
                var movieId = await connection.QuerySingleOrDefaultAsync<int>(@"select mId from tblMovie where mTitle=@mTitle", new { mTitle = movies.mTitle });
                if (movieId == 0)
                {
                    var mId = await connection.QuerySingleAsync<int>(query, movies);
                    await _movieCastRepo.AddMoviesCast(mc, res, mId, movies.rol, movies.createdBy);
                    await _directionRepository.AddmovieDirection(md, mId, movies.dId,movies.createdBy);
                     ret = await connection.QuerySingleOrDefaultAsync<int>(@"select noofMovies from tblDirector where dId=@dId ", new { noofMovies = ret, movies.dId }); 
                    ret += 1;

                    await _directorRepo.UpdateDirector(movies.dId, ret);
                  //  await connection.ExecuteAsync("update tblDirector set noofMovies=@noofMovies where dId=@dId", new {  dId = movies.dId });
                    return mId;
                }
                else
                    await _movieCastRepo.AddMoviesCast(mc, res, movieId, movies.rol, movies.createdBy);
                await _directionRepository.AddmovieDirection(md, movieId, movies.dId, movies.createdBy);
                return movieId;
            }
        }

        public Task<int> DeleteMovies(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            var query = "select * from tblMovie";
            using(var connection=_context.CreateConnection())
            {
                var result = await connection.QueryAsync<Movie>(query);
                return result.ToList();
            }
        }

        public Task<int> UpdateMovies(Movie movies)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddNewRealeaseList(MovieTicketPrice movieticketprice)
        {
            string query = "insert into tblMovieTicketPrice (mTitle,tPrice,mId) values(@mTitle,@tPrice,@mId)";
            using (var connection = _context.CreateConnection())
            {
                var moviename = await connection.QuerySingleOrDefaultAsync(@"select*from tblMovie where mTitle=@mTitle", new { mTitle = movieticketprice.mTitle });
                if (moviename == null)
                {
                    return 0;
                }
                else
                {
                    var resutl = await connection.ExecuteAsync(query, movieticketprice);

                    
                    return resutl;
                }
            }

        }
    }
}
