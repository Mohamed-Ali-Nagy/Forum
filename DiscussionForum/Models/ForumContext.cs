using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiscussionForum.Models
{
    public class ForumContext:IdentityDbContext<ApplicationUser>
    {
        public ForumContext(DbContextOptions options):base(options) { }
        
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Report> Reports { get; set; }

    }
}
