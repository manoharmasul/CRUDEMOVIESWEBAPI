namespace CRUDEMOVIESWEBAPI.Model
{
    public class Rating: BaseModelClass
    {
        //rId,mId,rating,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted

        public int ratId { get; set; }
        public int mId { get; set; }
        public double rating { get; set; }
     
    }
}
