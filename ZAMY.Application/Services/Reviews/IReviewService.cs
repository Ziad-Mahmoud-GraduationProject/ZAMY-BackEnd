
namespace ZAMY.Application.Services.Reviews
{
    public interface IReviewService
    {
        PagedList<Review> GetAll(PaginationParameters paginationParameters);
        PagedList<Review> NewersReview(PaginationParameters paginationParameters);
        PagedList<Review> OldersReview(PaginationParameters paginationParameters);
        Review GetById(int id);
        Review Add(Review review);
        Review Update(Review review);
        Review Delete(Review review);
            

    }
}
