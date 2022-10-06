using CRUDEMOVIESWEBAPI.Context;
using CRUDEMOVIESWEBAPI.Model;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using Dapper;
using System.Security.Cryptography;

namespace CRUDEMOVIESWEBAPI.Repository
{
    public class ActorRepository: IActorRepository
    {
      // Movie movies = new Movie();
        private readonly IMovieRepository _movieRepo;

        private readonly DapperContext _dapperContext;
        public ActorRepository(DapperContext dapperContext,IMovieRepository movieRepository)
        {
            _dapperContext = dapperContext;
            _movieRepo = movieRepository;
        }

        public async Task<int> AddNewActor(Actor actor)
        {
            Movie movies = new Movie();
            Actor actor2 = null;

            // aId,aName,aGender,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted
            var query = @"insert into tblActor (aName,aGender,createdBy,createdDate,isDeleted) 
                         values (@aName,@aGender,@createdBy,@createdDate,0);SELECT CAST(SCOPE_IDENTITY() as int)";

            movies = actor.movie;
            using (var connection=_dapperContext.CreateConnection())
            {
                var res  = await connection.QuerySingleOrDefaultAsync<int>(@"select aId from tblActor where aName=@aName and isDeleted=0", new {aName=actor.aName});
                if (res == 0)
                {
                    var aid = await connection.QuerySingleAsync<int>(query,actor);
                    await _movieRepo.AddNewMovie(movies, aid);
                    return aid;
                 //   await _movieRepo.AddNewMovie(movies, res);
                }
                else
                    await _movieRepo.AddNewMovie(movies, res);

                return - 1;
            }
        }

        public Task<int> DeleteActor(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Actor>> GetAllActors()
        {
            var query = "select * from tblActor where isDeleted=0";
            using(var connection=_dapperContext.CreateConnection())
            {
                var result=await connection.QueryAsync<Actor>(query);
                return result.ToList();
            }
        }

        public async Task<int> UpdateActor(Actor actor)
        {
            var query = "update tblActor set aName=@aName where aId=@aId and isDeleted=0";
            using(var connections=_dapperContext.CreateConnection())
            {
                var result=await connections.ExecuteAsync(query,actor);
                return result;
            }
        }
    }
}
