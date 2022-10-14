using CRUDEMOVIESWEBAPI.MallModel;
using CRUDEMOVIESWEBAPI.ShoppingRepository.InterfaceShoping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDEMOVIESWEBAPI.ControllerForBank
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopingController : ControllerBase
    {
        private readonly IShopingRepository _shopRepos;
        public ShopingController(IShopingRepository shopRepos)
        {
            _shopRepos = shopRepos;
        }
        [HttpPost("BOOK MOVIE TICKET")]
        public async Task<IActionResult> BookTicket(int mId ,int custId, int bId)
        {
            if(custId!=0||mId!=0||bId!=0)
            { 
            var result=await _shopRepos.TicketBooking(mId, custId, bId);
           
                if (result == 0)
                {
                    return NotFound();

                }

                else if (result == -3)
                {
                    return StatusCode(500, "Your Transaction Not  complited because your account balance not enough....!");
                }
                else if (result == -4)
                {

                    return StatusCode(200, "Your account balace is not enough...but your transaction is complited by creadit");

                }
                else
                    return StatusCode(200, "Your Ticket Booking is Success full...!");
            }
            else
            {
                return StatusCode(500, "request is empty");
            }
        }
        [HttpPost("Shop Now")]
        public async Task<IActionResult> ShopNow(OrderDeatails orderDeatails)
        {
            var result=await _shopRepos.PlaceOrder(orderDeatails);
            if (orderDeatails != null)
            {
                if (result == 0)
                {
                    return StatusCode(500, "Something Is Worng...!");
                }
                else if (result == -1)
                {
                    return StatusCode(500, "Product Not Exists");
                }
                else if(result==-3)
                {
                    return StatusCode(500,"Your Order Not Placed because your account balance not enough....!");
                }
                else if(result==-4)
                {
                      
                        return StatusCode(200, "Your account balace is not enough...but your transaction is complited by creadit");
                    
                }

                else return StatusCode(200, "Order Placed successfully");
            }
            else
                return StatusCode(500, "Order is empty");
        }
    }
}
