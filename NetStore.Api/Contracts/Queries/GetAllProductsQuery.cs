using Microsoft.AspNetCore.Mvc;

namespace NetStore.Api.Contracts.Queries
{
    public class GetAllProductsQuery
    {
        [FromQuery(Name = "title")]
        public string n { get; set; }

    }
}
