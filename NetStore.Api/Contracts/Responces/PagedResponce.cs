using System.Collections.Generic;

namespace NetStore.Api.Contracts.Responces
{
    public class PagedResponce<T>
    {
        public PagedResponce()
        {

        }
        public PagedResponce(ICollection<T> data)
        {
            Data = data;
        }
        public ICollection<T> Data { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string NextPage { get; set; }
        public string PreviousPage { get; set; }
    }
}
