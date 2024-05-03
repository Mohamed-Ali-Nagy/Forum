namespace DiscussionForum.Helper
{
    public class PaginationResult<T>
    {
        public IEnumerable<T> List { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public PaginationResult(IEnumerable<T>list,int size,int index)
        {
            List = list;
            PageSize = size;
            PageIndex = index;
        }
    }
}
