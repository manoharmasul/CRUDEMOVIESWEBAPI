using CRUDEMOVIESWEBAPI.Context;
using CRUDEMOVIESWEBAPI.Model;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using Dapper;

namespace CRUDEMOVIESWEBAPI.Repository
{
    public class ReviewerRepository: IReviwerRepository
    {
        Rating ratingobj = new Rating();

        private readonly DapperContext _dapperContext;  
        private readonly IRatingRepository _relationRepository;

        public ReviewerRepository(DapperContext dapperContext,IRatingRepository ratingRepository)

        {
            _relationRepository = ratingRepository;
            _dapperContext = dapperContext;
        }

        public async Task<int> AddReview(Reviewer reviewer)
        {
            //rId,mId,reviewerName,prating,reviewDescription,createdBy,modifiedBy,modifiedDate,isDeleted

            var query = "insert into tblReviewer(mId,reviewerName,prating,reviewDescription,createdBy,isDeleted) values (@mId,@reviewerName,@prating,@reviewDescription,@createdBy,0)";
           using(var connection=_dapperContext.CreateConnection())
            {
                var mId=await connection.QuerySingleOrDefaultAsync<int>("select mId from tblMovie where mId=@mId", new {mId=reviewer.mId});
                if (mId != 0)
                {
                    var result = await connection.ExecuteAsync(query, reviewer);
                    //Rating ratingobj = new Rating();
                    var ratmId = await connection.QuerySingleOrDefaultAsync<int>(@"select mId from tblRating where mId=@mId", new { mId = reviewer.mId });
                    if (ratmId == 0)
                    {
                        ratingobj.mId = reviewer.mId;
                        ratingobj.rating = reviewer.prating;
                        ratingobj.createdBy = reviewer.createdBy;
                       var ttt= await _relationRepository.AddRating(ratingobj);


                    }
                    else
                    {
                        var rat = await connection.QuerySingleOrDefaultAsync<int>(@"select avg(prating) from tblReviewer where mId=@mId", new
                        {
                            mId = reviewer
                        .mId
                        });

                        ratingobj.mId = reviewer.mId;



                        ratingobj.rating = rat;
                        ratingobj.modifiedBy = reviewer.rId;

                        await _relationRepository.UpdateRating(ratingobj);
                    }
                    return result;
                }
                else
                    return 0;
            }
        }

        public async Task<int> UpdateReview(Reviewer reviewer)
        {
            var query = "update tblReviewer set rating=@rating,modifiedBy,@modifiedBy,modifiedDate=getdate() where mId=@mId";
            using( var connection=_dapperContext.CreateConnection())

            {
                var result = await connection.ExecuteAsync(query, reviewer);
                return result;

            }
        }
    }
}
