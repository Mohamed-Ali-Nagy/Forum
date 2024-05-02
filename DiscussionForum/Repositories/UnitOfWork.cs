using DiscussionForum.Models;

namespace DiscussionForum.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ForumContext _forumContext;
        public IBaseRepository<Answer> Answers {  get;private set; }

        public IBaseRepository<Question> Questions {  get; private set; }

        public IBaseRepository<Like> Likes {  get; private set; }

        public IBaseRepository<Report> Reports { get; private set; }
        public UnitOfWork(ForumContext forumContext)
        {

            _forumContext = forumContext;
            Answers = new BaseRepository<Answer>(_forumContext);
            Questions = new BaseRepository<Question>(_forumContext);
            Likes = new BaseRepository<Like>(_forumContext);
            Reports = new BaseRepository<Report>(_forumContext);

        }
        public  int Complete()
        {
            return  _forumContext.SaveChanges();
        }

        public void Dispose()
        {
            _forumContext.Dispose();
        }
    }
}
