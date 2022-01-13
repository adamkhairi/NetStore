using System.Collections.Generic;
using AutoMapper;
using NetStore.Api.Contracts;
using NetStore.Api.Contracts.Queries;
using NetStore.Api.Contracts.Requests;
using NetStore.Api.Contracts.Responces;
using NetStore.Shared.Dto;
using NetStore.Shared.Models;

namespace NetStore.Api.Helpers
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<ApplicationUser, RegisterModel>();
            CreateMap<RegisterModel, ApplicationUser>();
            CreateMap<ApplicationUser, AuthModel>();
            CreateMap<ApplicationUser, ApplicationUser>();
            CreateMap<EditUserModel, RegisterModel>();
            CreateMap<ApplicationUser, UserModel>();
            
            
            CreateMap<AddProductDTO, Product>();
            CreateMap<Product, AddProductDTO>();
            CreateMap<OrderProduct, ResponceOrderDto>();
            CreateMap<OrderProduct, ResponceOrderDetailDto>();
            CreateMap<PaginationQuery, PaginationFilter>();
            CreateMap<GetAllProductsQuery, GetAllProductsFilter>();
            CreateMap<List<Order>, List<ResponceOrderDto>>();
            CreateMap<List<Product>, List<ResponceProductDTO>>();
            CreateMap<Product, ResponceProductDTO>();
            CreateMap<Order, ResponceOrderDto>();
         
        }
    }
}