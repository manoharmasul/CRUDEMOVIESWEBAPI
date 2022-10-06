namespace CRUDEMOVIESWEBAPI.Model
{
    public class Actor: BaseModelClass
    {
        //aId,aName,aGender,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted
        public int aId { get; set; }
        public string aName { get; set; }
        public string aGender { get; set; }
        public Movie movie{ get; set; } 

    }
}
