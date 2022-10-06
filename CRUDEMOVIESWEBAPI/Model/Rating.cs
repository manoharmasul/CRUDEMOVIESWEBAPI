namespace CRUDEMOVIESWEBAPI.Model
{
    public class Rating
    {
        //rId,mId,rating,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted

        public int ratId { get; set; }
        public int mId { get; set; }
        public double rating { get; set; }
        public int createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public int modifiedBy { get; set; }
        public DateTime modifiedDate { get; set; }
        public int isDeleted { get; set; }
    }
}
