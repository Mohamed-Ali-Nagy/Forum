
using DiscussionForum.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace DiscussionForum.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ForumContext _forumContext;
        public BaseRepository(ForumContext forumContext)
        {
            _forumContext = forumContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _forumContext.Set<T>().AddAsync(entity);
            await _forumContext.SaveChangesAsync();
            return entity;
        }
        public void Delete(T entity)
        {
            _forumContext.Set<T>().Remove(entity);
            _forumContext.SaveChanges();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await  _forumContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _forumContext.Set<T>().FindAsync(id);
        }
        public async Task<T> Update(T entity)
        {
            _forumContext.Update(entity);
            await _forumContext.SaveChangesAsync();
            return entity;
        }
    }
}
