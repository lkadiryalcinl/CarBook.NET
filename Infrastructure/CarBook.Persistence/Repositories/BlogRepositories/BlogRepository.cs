using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BlogBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetAllBlogsWithAuthor()
        {
            var values = await _context.Blogs.Include(x => x.Author).Include(x => x.Category).ToListAsync();
            return values;
        }

        public async Task<List<Blog>> GetLast3BlogsWithAuthor()
        {
            var values = await _context.Blogs.Include(x => x.Author).OrderByDescending(x => x.ID).Take(3).ToListAsync();
            return values;
        }
    }
}
