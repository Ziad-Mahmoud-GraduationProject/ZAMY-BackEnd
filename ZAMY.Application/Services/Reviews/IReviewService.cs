using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Application.Services.Reviews
{
    public interface IReviewService
    {
        IEnumerable<Review> GetAll();
        IEnumerable<Review> NewersReview();
        IEnumerable<Review> OldersReview();
        Review GetById(int id);
        Review Add(Review review);
        Review Update(Review review);
        Review Delete(Review review);
            

    }
}
