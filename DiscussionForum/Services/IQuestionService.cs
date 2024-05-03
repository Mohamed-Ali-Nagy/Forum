using DiscussionForum.Models;

namespace DiscussionForum.Services
{
    public interface IQuestionService
    {
       Task<Question> AddAsync(Question question);

       Task<Question> EditAsync(Question question);

        Task DeleteAsync(Question question);
        Task<Question> GetByIdAsync(int id);

        Task<IEnumerable<Question>> GetAllAsync();



    }
}
