using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Comments.Models;
using System.Linq;

namespace SimplCommerce.Module.Comments.Data
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IQueryable<CommentListItemDto> List();
    }
}