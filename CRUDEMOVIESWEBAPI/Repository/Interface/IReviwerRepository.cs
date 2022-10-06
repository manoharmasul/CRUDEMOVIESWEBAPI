using CRUDEMOVIESWEBAPI.Model;

namespace CRUDEMOVIESWEBAPI.Repository.Interface
{
    public interface IReviwerRepository
    {
        Task<int> AddReview(Reviewer reviewer);
        Task<int> UpdateReview(Reviewer reviewer);

    }
}
