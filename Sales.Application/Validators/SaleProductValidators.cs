using FluentValidation;
using Sales.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Validators
{
    public class SaleProductValidators : AbstractValidator<CreateSalesProductDto>
    {
        public SaleProductValidators() 
        { 
            RuleFor(x => x.SalesId).NotEmpty().WithMessage("Sales Id is Required");

            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product Id is Required");

            RuleFor(x => x.ProductQuantity).NotEmpty().WithMessage("Product Quantity is required");
        }
    }
}
