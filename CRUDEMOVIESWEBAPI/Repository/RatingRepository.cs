using CRUDEMOVIESWEBAPI.Context;
using CRUDEMOVIESWEBAPI.Model;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using Dapper;

namespace CRUDEMOVIESWEBAPI.Repository
{
    public class RatingRepository: IRatingRepository
    {
        private readonly DapperContext _context;
        public RatingRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> AddRating(Rating rrating)
        {
            //ratId,mId,rating,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted

            var query = "insert into tblRating (mId,rating,createdBy,isDeleted) values (@mId,@rating,@createdBy,0)";
            using(var connection=_context.CreateConnection())
            {
              //  var qt = await connection.QuerySingleOrDefault(@"select rating from tblRating where mId=@mId", new { mId = rrating.mId });
                var result = await connection.ExecuteAsync(query, rrating);

                return result;
            }
        }
        public async Task<int> UpdateRating(Rating rrating)
        {
            var query = "update tblRating set rating=@rating,modifiedBy=@modifiedBy,modifiedDate=getdate() where mId=@mId";
            using(var connection=_context.CreateConnection())
            {
                var result=await connection.ExecuteAsync(query, rrating);
                return result;
                
            }
        }
    }
}
