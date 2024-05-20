using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscussionForum.Models
{
    public class Question
    {
        public int ID { get; set; }
  
        public string? Title { get; set; }

        public string? Content { get; set; }

        public DateTime Timestamp { get; set; }

        //navigation prop
        [ForeignKey("User")]
        public string UserID { get; set; }
        public virtual ApplicationUser? User { get; set; }

        public virtual ICollection<Answer>? Answers { get; set; } 

    }
}
