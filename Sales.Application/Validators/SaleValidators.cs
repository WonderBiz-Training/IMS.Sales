using FluentValidation;
using Sales.Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Validators
{
    public class SaleValidators : AbstractValidator<CreateSalesProductListDto>
    {
        public SaleValidators() 
        {
            RuleFor(x => x.SalesCode)
                .NotEmpty()
                .WithMessage("Sales Code is Required");
                
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("CustomerId is Reuiqred").NotEqual(Guid.Empty).WithMessage("Customer Id does not exists");

            RuleFor(x => x.SalesQuantity)
                .NotEmpty()
                .WithMessage("Sales Quantity is required");

            RuleFor(x => x.StatusId)
                .NotEmpty()
                .WithMessage("Status Id is required");

            RuleFor(x => x.LocationId)
                .NotEmpty()
                .WithMessage("Location Id is required");

            RuleFor(x => x.SalesDate)
                .NotEmpty()
                .WithMessage("Sales Date and Time is required");   
        }
    }
}
