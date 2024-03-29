

namespace ZAMY.Application.Services.Reviews
{
    public class ReviewService(IUnitOfWork _unitOfWork) : IReviewService
    {

        public IEnumerable<Review> GetAll(PaginationParameters paginationParameters)
        {
            return PagedList<Review>
                .GetPagedList(_unitOfWork.Reviews.GetAll(),
                paginationParameters.PageNumber,
                paginationParameters.PageSize);
        }


        public IEnumerable<Review> NewersReview(PaginationParameters paginationParameters)
        {
            return PagedList<Review>
                .GetPagedList(_unitOfWork.Reviews
                .FindAll(orderBy: r => r.ReviewDate, OrderBy.Descending),
                paginationParameters.PageNumber,
                paginationParameters.PageSize);
        }

        public IEnumerable<Review> OldersReview(PaginationParameters paginationParameters)
        {
            return PagedList<Review>
               .GetPagedList(_unitOfWork.Reviews
               .FindAll(orderBy: r => r.ReviewDate, OrderBy.Ascending),
               paginationParameters.PageNumber,
               paginationParameters.PageSize);
        }

        public Review GetById(int id) => _unitOfWork.Reviews.GetById(id);

        public Review Add(Review review)
        {
            _unitOfWork.Reviews.Add(review);
            _unitOfWork.Complete();
            return review;
        }

        public Review Update(Review review)
        {
            _unitOfWork.Reviews.Update(review);
            _unitOfWork.Complete();
            return review;
        }

        public Review Delete(Review review)
        {
            _unitOfWork.Reviews.Remove(review);
            _unitOfWork.Complete();
            return review;
        }

    }
}
