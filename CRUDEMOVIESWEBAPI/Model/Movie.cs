namespace CRUDEMOVIESWEBAPI.Model
{
    public class Movie: BaseModelClass
    {
        //mId,mTitle,mBudget,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted

        public int mId { get; set; }
        public string mTitle { get; set; }
        public double mBudget { get; set; }
        public string rol { get; set; }
        public int dId { get; set; }
    }
}
