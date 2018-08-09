using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Comments.Models;
using System.Linq;

namespace SimplCommerce.Module.Comments.Data
{
    public interface IReplyRepository : IRepository<Reply>
    {
        IQueryable<ReplyListItemDto> List();
    }
}
