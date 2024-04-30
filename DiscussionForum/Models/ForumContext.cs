using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DiscussionForum.Models
{
    public class ForumContext:IdentityDbContext<ApplicationUser>
    {
    }
}
