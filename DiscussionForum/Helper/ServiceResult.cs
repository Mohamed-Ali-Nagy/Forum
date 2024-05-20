namespace DiscussionForum.Helper
{
    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }

        public string ErrorMessage { get; set; }

        private ServiceResult(bool success,T data,string errorMessage)
        {
           Success = success;
            Data = data;
            ErrorMessage = errorMessage;
        }

        public static ServiceResult<T> Succeeded(T data)
        {
            return new ServiceResult<T>(true,data,null!);
        }
        public static ServiceResult<T> Failed(string errorMessage)
        {
            return new ServiceResult<T>(false,default!,errorMessage);
        }
    }
}
