namespace CRUDEMOVIESWEBAPI.Model
{
    public class BaseModelClass
    {
        public int createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public int modifiedBy { get; set; }
        public DateTime modifiedDate { get; set; }
        public int isDeleted { get; set; }
    }
}
