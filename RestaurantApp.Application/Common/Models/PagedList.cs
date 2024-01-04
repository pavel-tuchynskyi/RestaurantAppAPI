namespace RestaurantApp.Application.Common.Models
{
    public class PagedList<T>
    {
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public IEnumerable<T> Items { get; set; }
        protected PagedList()
        {
        }
        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize) : this()
        {
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalRecords = count;
            var totalPages = ((double)count / (double)pageSize);
            TotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            Items = items;
        }
    }
}
