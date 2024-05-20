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
        public async Task<ServiceResult<Question>> AddAsync(Question question)
        {
           if(question == null)
            {
                return ServiceResult<Question>.Failed("question can not be null");
            }
            try
            {
                
                var result=await _unitOfWork.Questions.AddAsync(question);
                await _unitOfWork.Complete();
                return ServiceResult<Question>.Succeeded(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<Question>.Failed("An error occurred during adding question.");
            }
        }
        public async Task<ServiceResult<Question>> DeleteAsync(int id)                 
        {
            Question question=await _unitOfWork.Questions.GetByIdAsync(id);
            try 
            {
                await _unitOfWork.Questions.Delete(question);
                await _unitOfWork.Complete();
                return ServiceResult<Question>.Succeeded(question);
            }catch (Exception ex)
            {
                return ServiceResult<Question>.Failed("error occurred while deleting the question ");
            }
           
        }
        public async Task<ServiceResult<Question>> EditAsync(Question question)
        {
            if (question == null)
            {
                return ServiceResult<Question>.Failed("question can not be null");
            }
            try
            {
                var result = await _unitOfWork.Questions.UpdateAsync(question);
                await _unitOfWork.Complete();
                return ServiceResult<Question>.Succeeded(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<Question>.Failed("An error occurred during updating question.");
            }
            
        }
        public async Task<ServiceResult<PaginationResult<QuestionResponsVM>>> GetAllAsync(int pageSize,int pageIndex)
        {
            try
            {
                string[] includeProperties = new string[] { "User", "Answers" };
                var questionList = await _unitOfWork.Questions.GetAllAsync(pageSize, pageIndex, includeProperties);
                var questionResponseList = questionList.Select(q => q.ToQuestionResponse()).ToList();
                int total = await _unitOfWork.Questions.CountAsync();
                var paginationResult = new PaginationResult<QuestionResponsVM>(questionResponseList, total, pageIndex);
                return ServiceResult<PaginationResult<QuestionResponsVM>>.Succeeded(paginationResult); //new PaginationResult<QuestionResponsVM>(questionResponseList, total, pageIndex);
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationResult<QuestionResponsVM>>.Failed("error occurred while retrive the questions");
            }
       
        }                                                             
        public async Task<ServiceResult<Question>> GetByIdAsync(int id)
        {
            try
            {
                var question = await _unitOfWork.Questions.GetByIdAsync(id);
                return ServiceResult<Question>.Succeeded(question);
            }
            catch (Exception ex)
            {
                return ServiceResult<Question>.Failed(ex.Message);
            }
          
        }
    }
}
