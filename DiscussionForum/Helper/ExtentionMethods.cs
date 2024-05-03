using DiscussionForum.Models;
using DiscussionForum.ViewModels;

namespace DiscussionForum.Helper
{
    public static class ExtentionMethods
    {
        public static QuestionResponsVM ToQuestionRespons(this Question question)
        {
            return new QuestionResponsVM() {

                ID = question.ID,
                Timestamp = question.Timestamp,
                Title = question.Title,
                Content = question.Content,
                UserID = question.UserID,
                UserImageURL=question.User.ImagePath,

            };
        }
    }
}
