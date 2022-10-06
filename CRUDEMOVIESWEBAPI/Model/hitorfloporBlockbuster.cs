namespace CRUDEMOVIESWEBAPI.Model
{
    public class hitorfloporBlockbuster
    {
        //Id,mId,horforB,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted

        public int Id { get; set; }
        public int mId { get; set; }
        public string horforB { get; set; }
        public int createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public int modifiedBy { get; set; }
        public DateTime modifiedDate { get; set; }
        public int isDeleted { get; set; }
    }
}
