namespace CRUDEMOVIESWEBAPI.Model
{
    public class Director: BaseModelClass
    {
        //dId,dName,noofMovies,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted

        public int dId { get; set; }
        public string dName { get; set; }
        public int noofMovies { get; set; }
        public int createdBy { get; set; }
       
    }
}
