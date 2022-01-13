using System;
using Microsoft.AspNetCore.WebUtilities;
using NetStore.Api.Contracts.Queries;

namespace NetStore.Api.Services.UriService
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri + "api/v1/Store";
        }
        public Uri GetAllUri(PaginationQuery paginationQuery = null)
        {
            var uri = new Uri(_baseUri);
            if (paginationQuery == null) return uri;

            var modifiedUri = QueryHelpers.AddQueryString(_baseUri, "PageNumber", paginationQuery.PageNumber.ToString());

            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "PageSize", paginationQuery.PageSize.ToString());

            return new Uri(modifiedUri);
        }

        public Uri GetUri(string uri)
        {
            //return new Uri(_baseUri + )
            return new Uri(_baseUri);
        }
    }
}
