using DiscussionForum.Helper;
using DiscussionForum.Models;
using DiscussionForum.ViewModels;

namespace DiscussionForum.Services
{
    public interface IQuestionService
    {
       Task<ServiceResult<Question>> AddAsync(Question question);

        Task<ServiceResult<Question>> EditAsync(Question question);

        Task<ServiceResult<Question>> DeleteAsync(int id);
        Task<ServiceResult<Question>> GetByIdAsync(int id);

        Task<ServiceResult<PaginationResult<QuestionResponsVM>>> GetAllAsync(int pageSize,int pageIndex);



    }
}
