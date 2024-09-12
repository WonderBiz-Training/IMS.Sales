using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Sales.Api.Controllers;
using Sales.Api.DTOs;
using Sales.Application.Interfaces;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Sales.Tests.Sales_TestCases
{
    public class SalesControllerTestCases
    {
        private readonly ISalesServices _salesServices;

        public SalesControllerTestCases()
        {
            _salesServices = A.Fake<ISalesServices>();
        }

        [Fact]
        public async Task CreateSalesTest()
        {

            var controller = new SalesController(_salesServices);
            // Arrange
            var saleId = Guid.NewGuid(); // Simulate the sale ID that would be returned by the service

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

            var fakeSalesDto = new GetSalesDto
                (
                    saleId,  
                    sales.SalesCode,
                    sales.CustomerId,
                    sales.SalesQuantity,
                    sales.SalesTotal,
                    sales.DiscountId,
                    sales.DiscountedTotal,
                    sales.TaxId,
                    sales.TaxedTotal,
                    sales.StatusId,
                    sales.LocationId,
                    sales.SalesDate
                );

            A.CallTo(() => _salesServices.CreateSaleHeaderAsync(A<CreateSalesProductListDto>.Ignored))
                .Returns(Task.FromResult(fakeSalesDto));

            // Act

            var res = await controller.Post(sales);
            var response = (res.Result as OkObjectResult)?.Value as GetSalesDto;


            // Assert
            response.Should().NotBeNull();
            response.Should().BeEquivalentTo(fakeSalesDto);
        }

        [Fact]
        public async Task CreateSalesTest2_SalesCodeUniqueViolation_ReturnsBadRequest()
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

            A.CallTo(() => _salesServices.CreateSaleHeaderAsync(A<CreateSalesProductListDto>.Ignored))
                .Throws(new Exception("Duplicate Sales Code"));

            // Act
            var res = await controller.Post(sales);

            // Assert
            res.Result.Should().BeOfType<NotFoundObjectResult>(); 
            var response = (res.Result as NotFoundObjectResult)?.Value as string;
            response.Should().Be("Duplicate Sales Code");
        }

        [Fact]
        public async Task Createsalestest3_missingcustomerid_returnsbadrequest()
        {
            // arrange
            var controller = new SalesController(_salesServices);

            var sales = new CreateSalesProductListDto(
                SalesCode: "123",
                CustomerId: Guid.Empty,
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

            // act
            var res = await controller.Post(sales);

            // assert
            res.Result.Should().BeOfType<BadRequestObjectResult>();
            var response = (res.Result as BadRequestObjectResult)?.Value as string;
            response.Should().Contain("customerid is required"); 
        }


    }
}

