namespace CRUDEMOVIESWEBAPI.Model
{
    public class movieCast: BaseModelClass
    {
        //castId,aId,mId,rol,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted
        public int castId { get; set; }
        public int aId { get; set; }
        public int mId { get; set; }
        public string rol { get; set; }
       
    }
}
