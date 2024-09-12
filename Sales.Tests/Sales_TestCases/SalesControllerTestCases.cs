using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Sales.Api.Controllers;
using Sales.Api.DTOs;
using Sales.Application.Interfaces;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Tests.Sales_TestCases
{
    public class SalesControllerTestCases : IClassFixture<ISalesServices>
    {
        private readonly ISalesServices _salesServices;

        public SalesControllerTestCases(ISalesServices salesServices)
        {
            _salesServices = salesServices;
        }

        [Fact]
        public async Task CreateSalesTest()
        {
            // Arrange
            var controller = new SalesController(_salesServices);

            var sales = new CreateSalesProductListDto(
                SalesCode: "123",
                CustomerId: new Guid("123e4567-e89b-12d3-a456-426614174000"),
                SalesQuantity: 1,
                SalesTotal: 200,
                DiscountId: Guid.Empty, 
                DiscountedTotal: 200,
                TaxId: Guid.Empty, 
                TaxedTotal: 200,
                StatusId: new Guid("123e4567-e89b-12d3-a456-426614174000"),
                LocationId: new Guid("123e4567-e89b-12d3-a456-426614174000"),
                SalesDate: DateTime.Now,
                CreadtedBy: Guid.Empty, 
                SaleProducts: new List<SaleProduct>()
            );

            // Act
            var actionResult = await controller.Post(sales); 
            var createdSales = (actionResult.Result as OkObjectResult)?.Value as GetSalesDto;

            // Assert
            Assert.NotNull(createdSales);
            Assert.Equivalent(actionResult, createdSales);
        }


    }
}
