using DiscussionForum.Helper;
using DiscussionForum.Models;
using DiscussionForum.Repositories;
using DiscussionForum.ViewModels;

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
        public async Task<PaginationResult<QuestionResponsVM>> GetAllAsync(int pageSize,int pageIndex)
        {
            string[]includeProperties= new string[] {"User","Answers"};
            var questionList= await _unitOfWork.Questions.GetAllAsync(pageSize, pageIndex, includeProperties);
            var questionResponseList=questionList.Select(q=>q.ToQuestionResponse()).ToList();
            int total = await _unitOfWork.Questions.CountAsync();
            return new PaginationResult<QuestionResponsVM>(questionResponseList,total,pageIndex);
        }
        public async Task<Question> GetByIdAsync(int id)
        {
            return await _unitOfWork.Questions.GetByIdAsync(id);
        }
    }
}
