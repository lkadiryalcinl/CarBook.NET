using CarBook.Application.Interfaces.CommentInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CarBookContext _context;

        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }
        public async Task<List<Comment>> GetCommentsByBlogId(int id)
        {
            var values = await _context.Comments.Where(x => x.BlogID == id).ToListAsync();
            return values;
        }
    }
}
