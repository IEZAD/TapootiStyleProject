namespace _0_Framework.Domain.Pagination
{
    public class PagedResult<T> where T : class
    {
        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, RowCount); }
        }

        public int FirstRowOnPage
        {
            get { return (CurrentPage - 1) * PageSize + 1; }
        }

        public int PageSize { get; set; }

        public int RowCount { get; set; }

        public int PageCount { get; set; }

        public IList<T> Data { get; set; }

        public int CurrentPage { get; set; }

        public PagedResult()
        {
            Data = new List<T>();
        }
    }
}