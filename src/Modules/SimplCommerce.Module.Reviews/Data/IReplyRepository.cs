using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Reviews.Models;
using System.Linq;

namespace SimplCommerce.Module.Reviews.Data
{
    public interface IReplyRepository : IRepository<Reply>
    {
        IQueryable<ReplyListItemDto> List();
    }
}
