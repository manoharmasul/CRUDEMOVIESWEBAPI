namespace CRUDEMOVIESWEBAPI.Model
{
    public class BaseModelClass
    {
        public int createdBy { get; set; }
        public int createdDate { get; set; }
        public int modifiedBy { get; set; }
        public int modifiedDate { get; set; }
        public int isDeleted { get; set; }
    }
}
