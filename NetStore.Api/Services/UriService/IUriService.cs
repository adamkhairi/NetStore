using System;
using NetStore.Api.Contracts.Queries;

namespace NetStore.Api.Services.UriService
{
    public interface IUriService
    {
        Uri GetUri(string uri);
        Uri GetAllUri(PaginationQuery paginationQuery = null);
    }
}
