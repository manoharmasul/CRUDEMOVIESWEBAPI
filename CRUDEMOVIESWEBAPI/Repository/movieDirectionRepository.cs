using CRUDEMOVIESWEBAPI.Context;
using CRUDEMOVIESWEBAPI.Model;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using Dapper;

namespace CRUDEMOVIESWEBAPI.Repository
{
    public class movieDirectionRepository: ImovieDirectionRepository
    {
        Director director=new Director();
        private readonly IDirectorRepository directRepo;
        private readonly DapperContext _context;
        public movieDirectionRepository(DapperContext context, IDirectorRepository directRepo)
        {
            _context = context;
            this.directRepo = directRepo;   
        }

        public async Task<int> AddmovieDirection(movieDirection moviedirection,int mId,int dId,int cby)
        {
            //mdId,mId,dId,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted

            var query = "insert into tblmovieDirection(mId,dId,createdBy,isDeleted) values(@mId,@dId,@createdBy,@isDeleted)";
            using(var connection=_context.CreateConnection())
            {
                moviedirection.mId=mId;
                moviedirection.dId=dId;
                moviedirection.createdBy=cby;   

                var result = await connection.ExecuteAsync(query, moviedirection);
                return result;
            }
        }

        public Task DeletemovieDirection(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<movieDirection>> GetAllMoviesDirection()
        {
            var query = "select * from tblmovieDirection where isDeleted=0";
            using(var connections=_context.CreateConnection())
            {
                var result=await connections.QueryAsync<movieDirection>(query);
                return result.ToList();
            }
        }

        public Task<int> UpdatemovieDirection(movieDirection moviedirection)
        {
            throw new NotImplementedException();
        }
    }
}
