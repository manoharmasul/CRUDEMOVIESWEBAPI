namespace CRUDEMOVIESWEBAPI.Model
{
    public class Collection: BaseModelClass
    {
        //cId,mId,totalCollection,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted

        public int cId { get; set; }
        public int mId { get; set; }
        public double totalCollection { get; set; }
      
    }
}
