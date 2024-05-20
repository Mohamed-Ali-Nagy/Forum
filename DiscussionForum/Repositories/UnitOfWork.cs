using DiscussionForum.Models;
using Microsoft.AspNetCore.Identity;

namespace DiscussionForum.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ForumContext _forumContext;
        public IBaseRepository<Answer> Answers {  get;private set; }

        public IBaseRepository<Question> Questions {  get; private set; }

        public IBaseRepository<Like> Likes {  get; private set; }

        public IBaseRepository<Report> Reports { get; private set; }
        //public RoleManager<IdentityRole> roleManger { get; private set; }
        //public UserManager<ApplicationUser> userManager { get; private set; }
        public UnitOfWork(ForumContext forumContext)
        {

            _forumContext = forumContext;
            Answers = new BaseRepository<Answer>(_forumContext);
            Questions = new BaseRepository<Question>(_forumContext);
            Likes = new BaseRepository<Like>(_forumContext);
            Reports = new BaseRepository<Report>(_forumContext);
          //  roleManger = new RoleManager<IdentityRole>();

        }
        public  async Task<int> Complete()
        {
            return await  _forumContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _forumContext.Dispose();
        }
    }
}
