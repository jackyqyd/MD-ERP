namespace MDERP.Business.Models
{
    public class PageModel<T>
    {
        /// <summary>
        /// Current Page Index
        /// </summary>
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// Page Count
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// Data Total
        /// </summary>
        public int DataCount { get; set; } = 0;
        /// <summary>
        /// Page Size
        /// </summary>
        public int PageSize { set; get; }

        /// <summary>
        /// Query Condition
        /// </summary>
        public T QueryCriteria { get; set; }

        /// <summary>
        /// Return Data
        /// </summary>
        public List<T> Data { get; set; }
    }
}