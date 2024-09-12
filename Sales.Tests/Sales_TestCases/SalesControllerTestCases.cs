using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Sales.Api.Controllers;
using Sales.Application.Interfaces;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Tests.Sales_TestCases
{
    public class SalesControllerTestCases
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
            var sales = new Sale
            {
                SalesCode = "123",
                CustomerId = "123e4567-e89b-12d3-a456-426614174000",
                SalesQuantity = 1,
                StatusId = "123e4567-e89b-12d3-a456-426614174000",
                LocationId = "123e4567-e89b-12d3-a456-426614174000",
                SalesDate = DateTime.Now,
                SaleProducts = new List<SaleProduct>() // Properly initialize list
            };

            // Act
            var actionResult = await controller.Post(sales); // Await async method
            var createdSales = (actionResult as OkObjectResult)?.Value as Sale; // Properly cast the result

            // Assert
            Assert.NotNull(createdSales);
            Assert.AreEqual(sales.SalesCode, createdSales?.SalesCode);
            // Add more assertions as needed for validation
        }

    }
}
