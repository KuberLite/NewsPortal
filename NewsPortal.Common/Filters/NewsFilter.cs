using NewsPortal.Common.Enums;

namespace NewsPortal.Common.Filters
{
    public class NewsFilter
    {
        public int? Page { get; set; }

        public int? ItemsPerPage { get; set; }

        public NewsSources? Source { get; set; }

        public NewsSorting? Sorting { get; set; }
    }
}
