namespace CRUDEMOVIESWEBAPI.MallModel
{
    public class Order
    {
        //odId,oId,pId,Qty,totalAmmount
        public int odId { get; set; }
        public int oId { get; set; }
        public int pId { get; set; }
        public int Qty { get; set; }
        public double totalAmount { get; set; }
    }
}
