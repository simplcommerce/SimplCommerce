using MediatR;

namespace SimplCommerce.Module.Core.Events
{
    public class ReviewSummaryChanged : INotification
    {
        public long EntityId { get; set; }

        public string EntityTypeId { get; set; }

        public int ReviewsCount { get; set; }

        public double? RatingAverage { get; set; }
    }
}
