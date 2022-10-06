using CRUDEMOVIESWEBAPI.Context;
using CRUDEMOVIESWEBAPI.Model;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using Dapper;

namespace CRUDEMOVIESWEBAPI.Repository
{
    public class HitFlopOrBlockbusterRepository: IhitorfloporBlockbusterRepository
    {
        private readonly DapperContext _context;
        public HitFlopOrBlockbusterRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewHitOrFlopOrBlockbustrer(hitorfloporBlockbuster hitorflopor)
        {
            //Id,mId,horforB,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted

            var query = "insert into tblhitorfloporBlockbuster (mId,horforB,createdBy,isDeleted) values(@mId,@horforB,@createdBy,@isDeleted)";
            using(var connecton=_context.CreateConnection())
            {
                
                var result = await connecton.ExecuteAsync(query, hitorflopor);
              
                return result;
            }
        }

        public async Task<int> UpdateHitOrFlopOrBlockbustrer(hitorfloporBlockbuster hitorflopor)
        {
            var query = "update tblhitorfloporBlockbuster set horforB=@horforB,modifiedBy=@modifiedBy,modifiedDate=getdate() where mId=@mId";
            using (var connection = _context.CreateConnection())
            {
                var result=await connection.ExecuteAsync(query,hitorflopor);
                return result;
            }
        }
    }
}
