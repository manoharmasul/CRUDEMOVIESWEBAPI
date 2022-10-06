namespace CRUDEMOVIESWEBAPI.Model
{
    public class Movie
    {
        //mId,mTitle,mBudget,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted

        public int mId { get; set; }
        public string mTitle { get; set; }
        public double mBudget { get; set; }
        public int createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public int modifiedBy { get; set; }
        public DateTime modifiedDate { get; set; }
        public int isDeleted { get; set; }
        public string rol { get; set; }
        public int dId { get; set; }
    }
}
