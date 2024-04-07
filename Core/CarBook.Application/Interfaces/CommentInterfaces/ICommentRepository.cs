using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.CommentInterfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetCommentsByBlogId(int id);
        Task<int> GetCommentsCountByBlogId(int id);
    }
}
