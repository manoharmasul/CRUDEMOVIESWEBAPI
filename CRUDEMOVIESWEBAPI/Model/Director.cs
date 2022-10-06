namespace CRUDEMOVIESWEBAPI.Model
{
    public class Director
    {
        //dId,dName,noofMovies,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted

        public int dId { get; set; }
        public string dName { get; set; }
        public int noofMovies { get; set; }
        public int createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public int modifiedBy { get; set; }
        public DateTime modifiedDate { get; set; }
        public int isDeleted { get; set; }
    }
}
