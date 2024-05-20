using DiscussionForum.Models;

namespace DiscussionForum.Repositories
{
    public interface IUnitOfWork:IDisposable
    {
        public IBaseRepository<Answer> Answers { get;}
        public IBaseRepository<Question> Questions { get;}
        public IBaseRepository<Like> Likes { get;}
        public IBaseRepository<Report> Reports  { get;}
        Task<int> Complete();
    }
}
