using System;
using AutoMapper;
using Tragate.UI.Models.Category;
using Tragate.UI.Models.Company;
using Tragate.UI.Models.CompanyAdmin;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Dto.Quotation;
using Tragate.UI.Models.Product;
using Tragate.UI.Models.Quotation;
using Tragate.UI.Models.Response.CompanyAdmin;
using Tragate.UI.Models.User;

namespace Tragate.UI.BuildingBlocks.AutoMapper
{
    public class DtoToModelMappingProfile : Profile
    {
        public DtoToModelMappingProfile()
        {
            CreateMap<UserCompanyAdminListResponse, UserCompanyAdminListViewModel>()
                .ForMember(x => x.PageSize,
                    opt => opt.MapFrom(x => Convert.ToInt32(Math.Ceiling(x.TotalCount / 10.0))));

            CreateMap<CompanyAdminListResponse, CompanyAdminListViewModel>()
                .ForMember(x => x.PageSize,
                    opt => opt.MapFrom(x => Convert.ToInt32(Math.Ceiling(x.TotalCount / 10.0))));

            CreateMap<UserDto, UserProfileViewModel>()
                .ForMember(x => x.LocationName, opt => opt.MapFrom(x => x.Location.Name));

            CreateMap<UserDto, UserViewModel>();

            CreateMap<CompanyDto, CompanyProfileViewModel>()
                .ForMember(x => x.Location, opt => opt.MapFrom(x => x.User.Location.Name))
                .ForMember(x => x.CountryId, opt => opt.MapFrom(x => x.User.CountryId))
                .ForMember(x => x.StateId, opt => opt.MapFrom(x => x.User.StateId))
                .ForMember(x => x.CompanyId, opt => opt.MapFrom(x => x.User.UserId))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.User.UserName))
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(x => x.User.CreatedDate))
                .ForMember(x => x.ProfileImagePath, opt => opt.MapFrom(x => x.User.ProfileImagePath))
                .ForMember(x => x.UserStatus, opt => opt.MapFrom(x => x.User.Status))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.User.Email))
                .ForMember(x => x.BusinessTypeString, opt => opt.MapFrom(x => x.BusinessTypes));

            CreateMap<CompanyDto, CompanyDetailViewModel>()
                .ForMember(x => x.Location, opt => opt.MapFrom(x => x.User.Location.Name))
                .ForMember(x => x.CountryId, opt => opt.MapFrom(x => x.User.CountryId))
                .ForMember(x => x.StateId, opt => opt.MapFrom(x => x.User.StateId))
                .ForMember(x => x.CompanyId, opt => opt.MapFrom(x => x.User.UserId))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.User.UserName))
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(x => x.User.CreatedDate))
                .ForMember(x => x.ProfileImagePath, opt => opt.MapFrom(x => x.User.ProfileImagePath))
                .ForMember(x => x.BusinessTypeString, opt => opt.MapFrom(x => x.BusinessTypes));

            CreateMap<GroupCategoryDto, GroupCategoryViewModel>();

            CreateMap<RootCategoryDto, CategoryViewModel>();

            CreateMap<CategoryDto, GeneralCategoryViewModel>();


            CreateMap<CompanyAdminProductDto, CompanyAdminProductViewModel>();

            CreateMap<ProductUpdateViewModel, CompanyAdminUpdateProductDto>();

            CreateMap<ProductDetailDto, ProductUpdateViewModel>()
                 .ForMember(x => x.CompanyName, opt => opt.MapFrom(x => x.CompanyTitle));

            CreateMap<ProductUpdateViewModel, ProductAddViewModel>();

            CreateMap<UserDashboardDto, UserDashboardViewModel>();

            CreateMap<CompanyAdminDashboardDto, CompanyAdminDashboardViewModel>();

            CreateMap<CategoryDto, CategoryViewModel>()
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(x => x.Title));

            CreateMap<CompanyProductDto, CompanyProductViewModel>();


            CreateMap<ProductDetailDto, ProductDetailViewModel>();

            CreateMap<ProductDetailDto, ProductCopyViewModel>()
                .ForMember(x => x.CompanyName, opt => opt.MapFrom(x => x.CompanyTitle));

            CreateMap<ProductDto, ProductViewModel>()
                .ForMember(x => x.MembershipType, opt => opt.MapFrom(x => x.Company.MembershipType))
                .ForMember(x => x.CompanySlug, opt => opt.MapFrom(x => x.Company.Slug))
                .ForMember(x => x.CompanyName, opt => opt.MapFrom(x => x.Company.User.UserName));

            CreateMap<CompanyDto, CompanySearchViewModel>()
                .ForMember(x => x.ProfileImagePath, opt => opt.MapFrom(x => x.User.ProfileImagePath))
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.User.UserName))
                .ForMember(x => x.Location, opt => opt.MapFrom(x => x.User.Location.Name));

            CreateMap<CompanyDto, CompanyViewModel>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.User.UserName));

            CreateMap<QuotationListDto, QuotationUserBuyerViewModel>()
                .ForMember(x => x.SellerUser, opt => opt.MapFrom(x => x.SellerUser.FullName))
                .ForMember(x => x.SellerCompany, opt => opt.MapFrom(x => x.SellerCompany.FullName))
                .ForMember(x => x.SellerCompanyProfileImage, opt => opt.MapFrom(x => x.SellerCompany.ProfileImagePath));

            CreateMap<QuotationListDto, QuotationUserSellerViewModel>()
                .ForMember(x => x.SellerCompany, opt => opt.MapFrom(x => x.SellerCompany.FullName))
                .ForMember(x => x.BuyerUserProfileImage, opt => opt.MapFrom(x => x.BuyerUser.ProfileImagePath))
                .ForMember(x => x.BuyerUser, opt => opt.MapFrom(x => x.BuyerUser.FullName))
                .ForMember(x => x.BuyerUserCountry, opt => opt.MapFrom(x => x.BuyerUser.Country))
                .ForMember(x => x.BuyerUserEmail, opt => opt.MapFrom(x => x.BuyerUser.Email));

            CreateMap<QuotationListDto, QuotationCompanyBuyerViewModel>()
                .ForMember(x => x.BuyerUser, opt => opt.MapFrom(x => x.BuyerUser.FullName))
                .ForMember(x => x.SellerCompany, opt => opt.MapFrom(x => x.SellerCompany.FullName))
                .ForMember(x => x.SellerCompanyProfileImage, opt => opt.MapFrom(x => x.SellerCompany.ProfileImagePath))
                .ForMember(x => x.SellerUser, opt => opt.MapFrom(x => x.SellerUser.FullName));

            CreateMap<QuotationListDto, QuotationCompanySellerViewModel>()
                .ForMember(x => x.SellerUser, opt => opt.MapFrom(x => x.SellerUser.FullName))
                .ForMember(x => x.BuyerUser, opt => opt.MapFrom(x => x.BuyerUser.FullName))
                .ForMember(x => x.BuyerUserProfileImage, opt => opt.MapFrom(x => x.BuyerUser.ProfileImagePath));

            CreateMap<QuotationDto, QuotationViewModel>()
                .ForMember(x => x.BuyerUserId, opt => opt.MapFrom(x => x.BuyerUser.Id))
                .ForMember(x => x.BuyerUserFullName, opt => opt.MapFrom(x => x.BuyerUser.FullName))
                .ForMember(x => x.BuyerUserProfileImagePath, opt => opt.MapFrom(x => x.BuyerUser.ProfileImagePath))
                .ForMember(x => x.BuyerUserEmail, opt => opt.MapFrom(x => x.BuyerUser.Email))
                .ForMember(x => x.BuyerUserCountryId, opt => opt.MapFrom(x => x.BuyerUser.CountryId))
                .ForMember(x => x.SellerUserId, opt => opt.MapFrom(x => x.SellerUser.Id))
                .ForMember(x => x.SellerUserFullName, opt => opt.MapFrom(x => x.SellerUser.FullName))
                .ForMember(x => x.SellerUserCountryId, opt => opt.MapFrom(x => x.SellerUser.CountryId))
                .ForMember(x => x.SellerCompanyId, opt => opt.MapFrom(x => x.SellerCompany.Id))
                .ForMember(x => x.SellerCompanyName, opt => opt.MapFrom(x => x.SellerCompany.FullName))
                .ForMember(x => x.SellerCompanyLogo, opt => opt.MapFrom(x => x.SellerCompany.ProfileImagePath))
                .ForMember(x => x.BuyerCompany, opt => opt.MapFrom(x => x.BuyerCompany.FullName))
                .ForMember(x => x.BuyerCompanyId, opt => opt.MapFrom(x => x.BuyerCompany.Id))
                .ForMember(x => x.BuyerCompanyLogo, opt => opt.MapFrom(x => x.BuyerCompany.ProfileImagePath));

            CreateMap<QuotationProductDto, QuotationProductViewModel>();
            CreateMap<QuotationHistoryDto, QuotationHistoryViewModel>();
        }
    }
}