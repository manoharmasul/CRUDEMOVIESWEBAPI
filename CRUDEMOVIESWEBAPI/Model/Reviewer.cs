namespace CRUDEMOVIESWEBAPI.Model
{
    public class Reviewer: BaseModelClass
    {
        //rId,mId,reviewerName,prating,reviewDescription,createdBy,modifiedBy,modifiedDate,isDeleted
        public int rId { get; set; }
        public int mId { get; set; }
        public string reviewerName { get; set; }
        public int prating { get; set; }
        public string reviewDescription { get; set; }

     

    }
}
