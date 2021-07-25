using System.Linq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Reviews.Models;

namespace SimplCommerce.Module.Reviews.Data
{
    public interface IReplyRepository : IRepository<Reply>
    {
        IQueryable<ReplyListItemDto> List();
    }
}
