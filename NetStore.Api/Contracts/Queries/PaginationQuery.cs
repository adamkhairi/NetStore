namespace NetStore.Api.Contracts.Queries
{
    public class PaginationQuery
    {
        public PaginationQuery()
        {
            PageNumber = 1;
            PageSize = 24;
        }
        public PaginationQuery(int pagenumber,int pageSize)
        {
            PageNumber = pagenumber;
            PageSize = pageSize;
        }

        public int  PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
