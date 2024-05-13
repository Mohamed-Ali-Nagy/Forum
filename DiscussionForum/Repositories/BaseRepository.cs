
using DiscussionForum.Helper;
using DiscussionForum.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;

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
        //public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        //{
        //    IQueryable<T> query = context.Set<T>();
        //    query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        //    return await query.ToListAsync();
        //}
        public async Task<int> CountAsync()
        {
            return await _forumContext.Set<T>().CountAsync();
        }

        public async Task Delete(T entity)
        {
            _forumContext.Set<T>().Remove(entity);
           await _forumContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync(int pageSize,int index)
        {
           // PaginationResult<T> pageResult = new PaginationResult<T>();
            return await _forumContext.Set<T>().Skip((index-1)*pageSize).Take(pageSize).ToListAsync();
           // pageResult.TotalPages=await _forumContext.Set<T>().CountAsync();
            //pageResult.PageIndex=index;
           // return pageResult;
        }
        //public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null)
        //{
        //    IQueryable<T> query = _context.Set<T>();

        //    if (includes != null)
        //        foreach (var include in includes)
        //            query = query.Include(include);

        //    return query.Where(criteria).ToList();
        //}
        public async Task<IEnumerable<T>>GetAllAsync(int pageSize,int index, string[] includesProperties = null)
        {
            IQueryable<T> query=_forumContext.Set<T>();
            if(includesProperties != null)
            {
                foreach(var include in includesProperties)
                {
                    query=query.Include(include);
                }

            }
            return await query.ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _forumContext.Set<T>().FindAsync(id);
        }
        public async Task<T> UpdateAsync(T entity)
        {
            _forumContext.Update(entity);
            await _forumContext.SaveChangesAsync();
            return entity;
        }

      
    }
}
