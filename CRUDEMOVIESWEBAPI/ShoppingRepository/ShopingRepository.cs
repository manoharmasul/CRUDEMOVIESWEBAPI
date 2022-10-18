using CRUDEMOVIESWEBAPI.Context;
using CRUDEMOVIESWEBAPI.MallModel;
using CRUDEMOVIESWEBAPI.Model;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using CRUDEMOVIESWEBAPI.ShoppingRepository.InterfaceShoping;
using Dapper;
using LoandLoanAproveBankCustomer.Model;
using LoandLoanAproveBankCustomer.Repository.Interface;
using System.Runtime.InteropServices;

namespace CRUDEMOVIESWEBAPI.ShoppingRepository
{
    public class ShopingRepository: IShopingRepository
    {
        Collection cl = new Collection();
        private readonly ICollectionRepository _colleRepo;
        Customer cust = new Customer();
        private readonly ICustomerRepository _CustRepo;
        private readonly DapperContext _dapperContext;

        public ShopingRepository(DapperContext dapperContext,ICustomerRepository customerRepository,ICollectionRepository collectionRepository)
        {
            _dapperContext = dapperContext;
            _CustRepo = customerRepository; 
            _colleRepo = collectionRepository;  
        }

        public async Task<double> PlaceOrder(OrderDeatails orderDetails)
        {
            //oId,invoiceNo,customerName,mobileNo,shippingAddress,billingAddress,totalOrderAmmount

            var query = @"insert into tblOrderDetailss
            (invoiceNo,customerName,mobileNo,shippingAddress,billingAddress,totalOrderAmount) 
            values(@invoiceNo,@customerName,@mobileNo,@shippingAddress,@billingAddress,@totalOrderAmount);select scope_identity() as int";
            List<Order> odlist = new List<Order>();
            odlist=orderDetails.orderslist;

            using(var connection=_dapperContext.CreateConnection())
            {
              var result=await connection.QuerySingleAsync<int>(query,orderDetails);   

                  var total=await insertorder(orderDetails.orderslist, result);
                
                var result1 = await connection.ExecuteAsync("update tblOrderDetailss set totalOrderAmount=@totalOrderAmount where oId=@oId", new { oId = result, totalOrderAmount = total });
                if(result1==0)
                {
                    return result1;
                }
                var ret = await _CustRepo.Trnsaction(orderDetails.cId, total, "Debit");

                if (ret == -3)
                {

                    await connection.ExecuteAsync(@"delete tblOrderDetailss where oId=@oId", new { oId = result });
                    await connection.ExecuteAsync(@"delete tblOrderr where oId=@oId", new { oId = result });

                    
                    return ret;
                }
                else if(ret==-4)
                {
                    return ret;
                }

                return total;
            }
        }
        public async Task<double> insertorder(List<Order> orderlist,int orId)
        {
            double gdTotal=0;
            var query = "insert into tblOrderr(oId,pId,Qty,totalAmount) values(@oId,@pId,@Qty,@totalAmount)";
            using(var connection=_dapperContext.CreateConnection())
            {
                foreach (var od in orderlist)
                {
                    od.oId= orId;   
                   var result = await connection.QuerySingleOrDefaultAsync<double>("select price from tblProductt where pId=@pId", new { pId = od.pId });
                    if (result == 0)
                    {
                        return -1;
                    }
                    else
                    {
                        result = result*od.Qty;

                        od.totalAmount = result;

                        var resu = await connection.ExecuteAsync(query, od);
                        gdTotal += result;
                       
                    }
                  
                  
                }
                return gdTotal;
            }
        }

        public async Task<int> TicketBooking(int mId, int custId, int bId,int Qty)
        {
            using(var connection=_dapperContext.CreateConnection())
            {
                var ticketprice=await connection.QuerySingleOrDefaultAsync<double>
                (@"select tPrice from tblMovieTicketPrice where mId=@mId",new {mId=mId});
                ticketprice *= Qty;
                if(ticketprice==0)
                {
                    return 0;

                }
                else
                {
                    var ret = await _CustRepo.Trnsaction(custId, ticketprice, "Debit");

                    if (ret == -3)
                    {
          


                        return ret;
                    }
                    else if (ret == -4)
                    {
                        return ret;
                    }
                    cl.mId = mId;
                    cl.totalCollection = ticketprice;
                   
                  _colleRepo.AddMoviesCollection(cl);

                    return (int)ticketprice;
                }
               

            }
        }


    }
}
