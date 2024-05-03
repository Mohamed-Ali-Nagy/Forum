using DiscussionForum.Models;
using DiscussionForum.Repositories;

namespace DiscussionForum.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuestionService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Question> AddAsync(Question question)
        {
           return await _unitOfWork.Questions.AddAsync(question);
        }
        public async Task DeleteAsync(Question question)                 
        {
           await _unitOfWork.Questions.Delete(question);
        }
        public async Task<Question> EditAsync(Question question)
        {
            return await _unitOfWork.Questions.UpdateAsync(question);
        }
        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _unitOfWork.Questions.GetAllAsync();
        }
        public async Task<Question> GetByIdAsync(int id)
        {
            return await _unitOfWork.Questions.GetByIdAsync(id);
        }
    }
}
