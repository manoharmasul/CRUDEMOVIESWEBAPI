using CRUDEMOVIESWEBAPI.MallModel;

namespace CRUDEMOVIESWEBAPI.ShoppingRepository.InterfaceShoping
{
    public interface IShopingRepository
    {
        Task<int> TicketBooking(int mId, int custId, int bId,int Qty);
        Task<double> PlaceOrder(OrderDeatails orderDetails);
    }
}
