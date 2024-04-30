using System.ComponentModel.DataAnnotations.Schema;

namespace DiscussionForum.Models
{
    public class Answer
    {
        public int ID { get; set; }

        public string Content { get; set; }
        public DateTime Timestamp { get; set; }


        [ForeignKey("User")]
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey("Question")]
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }

        public virtual ICollection<Like>? Likes { get; set; }
    }
}
