using System.ComponentModel.DataAnnotations;

namespace DiscussionForum.ViewModels
{
    public class LogInVM
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public bool RememberMe { get; set; }
    }
}
