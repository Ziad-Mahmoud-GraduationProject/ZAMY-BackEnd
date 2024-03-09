using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Application.Services.Reviews
{
    public class ReviewService(IUnitOfWork _unitOfWork) : IReviewService
    {
 
        public IEnumerable<Review> GetAll()=>_unitOfWork.Reviews.GetAll();
        
        public IEnumerable<Review> NewersReview()=>_unitOfWork.Reviews.
                FindAll(orderBy:r=>r.ReviewDate , "DESC");
            
        public IEnumerable<Review> OldersReview() => _unitOfWork.Reviews.
                FindAll(orderBy: r => r.ReviewDate, "ASC");

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
