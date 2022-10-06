namespace CRUDEMOVIESWEBAPI.Model
{
    public class Collection
    {
        //cId,mId,totalCollection,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted

        public int cId { get; set; }
        public int mId { get; set; }
        public double totalCollection { get; set; }
        public int createdBy { get; set; }
        public int createdDate { get; set; }
        public int modifiedBy { get; set; }
        public int modifiedDate { get; set; }
        public int isDeleted { get; set; }
    }
}
