namespace CRUDEMOVIESWEBAPI.MallModel
{
    public class OrderDeatails
    {
        //oId,invoiceNo,customerName,mobileNo,shippingAdress,billingAddrress,totalOrderAmmount
        public int oId { get; set; }
        public int invoiceNo { get; set; }
        public string customerName { get; set; }
        public long mobileNo { get; set; }
        public string shippingAddress { get; set; }
        public string billingAddress { get; set; }
        public double totalOrderAmount { get; set; }
        public List<Order>  orderslist{ get; set; }
        public int cId { get; set; }

    }
}
