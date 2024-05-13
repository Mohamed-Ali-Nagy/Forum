using DiscussionForum.Helper;
using DiscussionForum.Models;
using DiscussionForum.ViewModels;

namespace DiscussionForum.Services
{
    public interface IQuestionService
    {
       Task<Question> AddAsync(Question question);

       Task<Question> EditAsync(Question question);

        Task DeleteAsync(Question question);
        Task<Question> GetByIdAsync(int id);

        Task<PaginationResult<QuestionResponsVM>> GetAllAsync(int pageSize,int pageIndex);



    }
}
