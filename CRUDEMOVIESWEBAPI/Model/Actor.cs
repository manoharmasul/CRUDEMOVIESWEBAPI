namespace CRUDEMOVIESWEBAPI.Model
{
    public class Actor
    {
        //aId,aName,aGender,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted
        public int aId { get; set; }
        public string aName { get; set; }
        public string aGender { get; set; }
        public int createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public int modifiedBy { get; set; }
        public  DateTime modifiedDate { get; set; }
        public int isDeleted { get; set; }
        public Movie movie{ get; set; } 

    }
}
