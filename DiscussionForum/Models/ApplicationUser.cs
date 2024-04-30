using Microsoft.AspNetCore.Identity;

namespace DiscussionForum.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? FullName { get; set; }
        public string? Bio { get; set; }
        public string? ImagePath { get; set; }

        public ICollection<Question>? Questions { get; set; }   
        public ICollection<Answer>? Answers  { get; set; }   
        public ICollection<Like>? Likes { get; set; }   
        public ICollection<Report>? ReportedUsers { get; set; }   
    }
}
