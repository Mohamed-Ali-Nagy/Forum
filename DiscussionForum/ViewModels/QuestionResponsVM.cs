using DiscussionForum.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscussionForum.ViewModels
{
    public class QuestionResponsVM
    {
        public int ID { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }
        public string? UserName { get; set; }
        public DateTime Timestamp { get; set; }
        public string UserID { get; set; } = null!;

        public string? UserImageURL { get; set; }



        //public virtual ApplicationUser User { get; set; }

        //public virtual ICollection<Answer>? Answers { get; set; }
    }
}
