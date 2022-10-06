namespace CRUDEMOVIESWEBAPI.Model
{
    public class Reviewer
    {
        //rId,mId,reviewerName,prating,reviewDescription,createdBy,modifiedBy,modifiedDate,isDeleted
        public int rId { get; set; }
        public int mId { get; set; }
        public string reviewerName { get; set; }
        public int prating { get; set; }
        public string reviewDescription { get; set; }

        public int createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public int modifiedBy { get; set; }
        public DateTime modifiedDate { get; set; }
        public int isDeleted { get; set; }

    }
}
