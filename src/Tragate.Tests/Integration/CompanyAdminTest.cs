using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Tragate.UI.Controllers;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Product;
using Tragate.UI.Models.Response;
using Tragate.UI.Services;
using Xunit;

namespace Tragate.Tests.Integration
{
    public class CompanyAdminTest : TestBase
    {
        private IProductService _productService;
        private IMapper _mapper;

        private CompanyAdminController GetCompanyAdminController(){
            var serviceProvider = base.BuildServiceProvider();

            var companyService = serviceProvider.GetService<ICompanyService>();
            var companyAdminService = serviceProvider.GetService<ICompanyAdminService>();
            _mapper = serviceProvider.GetService<IMapper>();
            var user = new Mock<IApplicationUser>();
            _productService = serviceProvider.GetService<IProductService>();
            var categoryService = serviceProvider.GetService<ICategoryService>();

            user.SetupProperty(x => x.UserId, 495);
            user.SetupProperty(x => x.Email, "bilal-islam@hotmail.com");
            return new CompanyAdminController(companyService, companyAdminService, _mapper, user.Object,
                _productService,
                categoryService);
        }

        [Theory]
        [InlineData(71)]
        public void Should_Return_Success_Product_Update_When_Nullable_Fields_Blank(int id){
            //Arrange
            var controller = GetCompanyAdminController();
            var product = _productService.GetProductById(id).Product;
            var model = _mapper.Map<ProductUpdateViewModel>(product);
            model.Id = id;
            model.CurrencyId = null;
            model.UnitTypeId = null;
            model.PriceLow = 0;
            model.PriceHigh = 0;
            model.Description = null;
            model.Brand = null;
            model.ModelNumber = null;
            model.MinimumOrder = null;
            model.SupplyAbility = null;

            //Act
            var actionResult = controller.EditProduct(model);

            //Assert
            var result = (JsonResult) actionResult;
            result.Value.Should().BeOfType<BaseResponse>();
            var response = result.Value as BaseResponse;
            Assert.NotNull(response);
            Assert.True(response.Success);
        }
    }
}