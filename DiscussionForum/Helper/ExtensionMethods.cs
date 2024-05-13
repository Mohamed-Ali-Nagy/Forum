using DiscussionForum.Models;
using DiscussionForum.ViewModels;

namespace DiscussionForum.Helper
{
    public static class ExtensionMethods
    {
        public static QuestionResponsVM ToQuestionResponse(this Question question)
        {
            return new QuestionResponsVM() {

                ID = question.ID,
                Timestamp = question.Timestamp,
                Title = question.Title,
                Content = question.Content,
                UserID = question.UserID,
                UserImageURL=question.User.ImagePath,
                UserName=question.User.UserName,

            };
        }
    }
}
