namespace DiscussionForum.Helper
{
    public class PaginationResult<T>
    {
        public IEnumerable<T> List { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public PaginationResult(IEnumerable<T>list,int totalPages,int index)
        {
            List = list;
            TotalPages = totalPages;
            PageIndex = index;
        }
        public PaginationResult()
        {
            List = null!;
            TotalPages =0;
            PageIndex = 1;
        }
    }
}
