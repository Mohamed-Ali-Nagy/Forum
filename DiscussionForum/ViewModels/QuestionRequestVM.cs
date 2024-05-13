using DiscussionForum.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscussionForum.ViewModels
{
    public class QuestionRequestVM
    {
        //public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Content { get; set; } = null!;
        //public DateTime Timestamp { get; set; }
        public string UserID { get; set; } = null!;

        public Question ToQuestion()
        {
            return new Question() { Title = Title, Content = Content, UserID = UserID,Timestamp=DateTime.UtcNow};
        }
    }
}
