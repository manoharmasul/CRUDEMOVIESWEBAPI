namespace CRUDEMOVIESWEBAPI.Model
{
    public class movieDirection
    {
        //mdId,mId,dId,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted
        public int mdId { get; set; }
        public int mId { get; set; }
        public int dId { get; set; }
        public int createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public int modifiedBy { get; set; }
        public DateTime modifiedDate { get; set; }
        public int isDeleted { get; set; }
    }
}
