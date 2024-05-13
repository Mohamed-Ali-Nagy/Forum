using System.ComponentModel.DataAnnotations;

namespace DiscussionForum.ViewModels
{
    public class SignUpVM
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string UserName {  get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        //public string PhoneNumber { get; set; } 
        [Required] 
        [DataType(DataType.Password)]          
        public string Password { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password dose not matches")]
        public string ConfirmPassword {  get; set; } = null!;
    }
}
