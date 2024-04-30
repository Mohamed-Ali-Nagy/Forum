using System.ComponentModel.DataAnnotations.Schema;

namespace DiscussionForum.Models
{
    public class Like
    {
        public int ID { get; set; }

        public DateTime Timestamp { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey("Answer")]
        public int AnswerID { get; set; }

        public Answer Answer { get; set; }
    }
}
