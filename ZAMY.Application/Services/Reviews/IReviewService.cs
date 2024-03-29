
namespace ZAMY.Application.Services.Reviews
{
    public interface IReviewService
    {
        IEnumerable<Review> GetAll(PaginationParameters paginationParameters);
        IEnumerable<Review> NewersReview(PaginationParameters paginationParameters);
        IEnumerable<Review> OldersReview(PaginationParameters paginationParameters);
        Review GetById(int id);
        Review Add(Review review);
        Review Update(Review review);
        Review Delete(Review review);
            

    }
}
