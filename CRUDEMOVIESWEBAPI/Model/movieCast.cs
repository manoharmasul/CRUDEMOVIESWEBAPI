namespace CRUDEMOVIESWEBAPI.Model
{
    public class movieCast
    {
        //castId,aId,mId,rol,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted
        public int castId { get; set; }
        public int aId { get; set; }
        public int mId { get; set; }
        public string rol { get; set; }
        public int createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public int modifiedBy { get; set; }
        public DateTime modifiedDate { get; set; }
        public int isDeleted { get; set; }
    }
}
