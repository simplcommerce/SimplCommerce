using MediatR;

namespace SimplCommerce.Module.Core.Events
{
    public class UserSignedIn : INotification
    {
        public long UserId { get; set; }
    }
}
