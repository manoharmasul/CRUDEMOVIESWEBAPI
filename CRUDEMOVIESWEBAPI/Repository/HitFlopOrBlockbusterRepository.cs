using CRUDEMOVIESWEBAPI.Context;
using CRUDEMOVIESWEBAPI.Model;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using Dapper;
using Microsoft.IdentityModel.Tokens;

namespace CRUDEMOVIESWEBAPI.Repository
{
    public class HitFlopOrBlockbusterRepository: IhitorfloporBlockbusterRepository
    {
        private readonly DapperContext _context;
        private int result;

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

        public async Task<HiFlopByActor> GetHitorflopor(int id)
        {
            HiFlopByActor obj = new HiFlopByActor();
            var query = @"select A.aName as ActorName,count(hfb.Id) as NoOfHits,
                       
                       (select count(hfb.horforB) from tblActor A 

                       inner join tblmovieCast mc on A.aId=mc.aId 

                       inner join tblMovie m on mc.mId=m.mId 

                       inner join tblhitorfloporBlockbuster hfb 

                       on m.mId=hfb.mId where A.aId=@aId) as totalNoMovies from tblActor A 

                       inner join tblmovieCast mc on A.aId=mc.aId 

                       inner join tblMovie m on mc.mId=m.mId 

                       inner join tblCollection c on   m.mId=c.mId 

                       inner join tblhitorfloporBlockbuster hfb 

                       on m.mId=hfb.mId where a.aId=@aId and hfb.horforB='hit' group by A.aName";

         // var query = "select count(*) from tblhitorfloporBlockbuster ";
            using (var connnection = _context.CreateConnection())

                obj.ResponseData= await connnection.QueryAsync(query, new {aId=id});

      
            return obj;




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
