using CRUDEMOVIESWEBAPI.Context;
using CRUDEMOVIESWEBAPI.Model;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using Dapper;
using Microsoft.AspNetCore.Components.Forms;

namespace CRUDEMOVIESWEBAPI.Repository
{
    public class CollectionRepository: ICollectionRepository
    {
        hitorfloporBlockbuster hitorflop=new hitorfloporBlockbuster();  
        private readonly IhitorfloporBlockbusterRepository _hitorfloporBlockbusterRepository;   

        private readonly DapperContext _dapperContext;  
        public CollectionRepository(DapperContext dapperContext, IhitorfloporBlockbusterRepository hitorfloporBlockbusterRepository)
        {
            _dapperContext = dapperContext;
            _hitorfloporBlockbusterRepository = hitorfloporBlockbusterRepository;   
        }

        public async Task<int> AddMoviesCollection(Collection collection)
        {
            //cId,mId,totalCollection,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted
       
            var query = "insert into tblCollection(mId,totalCollection,createdBy,isDeleted) values(@mId,@totalCollection,@createdBy,@isDeleted)";
            using(var connection=_dapperContext.CreateConnection())
            {
                var movieId = await connection.QuerySingleOrDefaultAsync<int>(@"select mId from tblMovie where mId=@mId", new { mId = collection.mId });
                if (movieId != 0)
                {
                    var movId = await connection.QuerySingleOrDefaultAsync<int>(@"select mId from tblCollection where mId=@mId", new { mId = collection.mId });
                    if (movId != 0)
                    {
                        var dummy = collection.createdBy;
                      //  collection.modifiedBy = dummy;
                        var update = await connection.ExecuteAsync("update tblCollection set totalCollection=@totalCollection,modifiedBy=@modifiedBy,modifiedDate=getDate() where mId=@mId", new { mId = movId, totalCollection=collection.totalCollection, modifiedBy = dummy });

                        var midhitflop = await connection.QuerySingleOrDefaultAsync<int>(@"select mId from tblhitorfloporBlockbuster where mId=@mId", new { mId = collection.mId });
                        if (midhitflop != 0)
                        {
                            var budget = await connection.QuerySingleAsync<double>(@"select mBudget from tblMovie where mId=@mId", new { collection.mId });
                            hitorflop.modifiedBy = collection.createdBy;
                            hitorflop.mId=collection.mId;   
                            if (budget > collection.totalCollection)
                                hitorflop.horforB = "flop";
                            else if (budget < collection.totalCollection && collection.totalCollection <= budget*1.5)
                            {
                                hitorflop.horforB = "hit";
                            }
                            else
                                hitorflop.horforB = "Blockbuster";
                            await _hitorfloporBlockbusterRepository.UpdateHitOrFlopOrBlockbustrer(hitorflop);
                            return -2;
                        }
                        else
                        {

                            var budget = await connection.QuerySingleAsync<double>(@"select mBudget from tblMovie where mId=@mId", new { collection.mId });
                            hitorflop.createdBy = collection.createdBy;
                            hitorflop.mId = collection.mId;
                          //  hitorflop.modifiedBy = collection.createdBy;
                            if (budget > collection.totalCollection)
                                hitorflop.horforB = "flop";
                            else if (budget < collection.totalCollection * 1.5)
                            {
                                hitorflop.horforB = "hit";
                            }
                            else
                                hitorflop.horforB = "Blockbuster";
                            await _hitorfloporBlockbusterRepository.AddNewHitOrFlopOrBlockbustrer(hitorflop);
                            return -3;

                        }
                    }


                    var result = await connection.ExecuteAsync(query, collection);
                      var budget1 = await connection.QuerySingleAsync<double>("select mBudget from tblMovie where mId=@mId", new { collection.mId });
                    hitorflop.createdBy = collection.createdBy;
                    hitorflop.mId=collection.mId;

                    if (budget1 > collection.totalCollection)
                        hitorflop.horforB = "flop";
                    else if (budget1 < collection.totalCollection * 1.5)
                    {
                        hitorflop.horforB = "hit";
                    }
                    else
                        hitorflop.horforB = "Blockbuster";
                    await _hitorfloporBlockbusterRepository.AddNewHitOrFlopOrBlockbustrer(hitorflop);  
                    
                        return result;

                }
                else
                    return -1;

            }
        }
    }
}
