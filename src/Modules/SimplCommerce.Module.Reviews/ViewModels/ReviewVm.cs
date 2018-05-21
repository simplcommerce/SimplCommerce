using System.Collections.Generic;

namespace SimplCommerce.Module.Reviews.ViewModels
{
    public class ReviewVm
    {
        public long EntityId { get; set; }

        public string EntityTypeId { get; set; }

        public int ReviewsCount { get; set; }

        public double RatingAverage
        {
            get
            {
                if (ReviewsCount > 0)
                {
                    return ((1 * Rating1Count) + (2 * Rating2Count) + (3 * Rating3Count) + (4 * Rating4Count) + (5 * Rating5Count)) / (double)ReviewsCount;
                }

                return 0;
            }
        }

        public double GetRatingPercent(int rateCount)
        {
            if (ReviewsCount > 0)
            {
                return (double)rateCount/ReviewsCount*100;
            }

            return 0;
        }

        public int Rating1Count { get; set; }

        public int Rating2Count { get; set; }

        public int Rating3Count { get; set; }

        public int Rating4Count { get; set; }

        public int Rating5Count { get; set; }

        public IList<ReviewItem> Items { get; set; } = new List<ReviewItem>();
    }
}
