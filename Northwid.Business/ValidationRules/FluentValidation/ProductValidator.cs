using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwid.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        //fluent validation
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.UnitPrice).NotEmpty();
            RuleFor(x => x.QuantityPerUnit).NotEmpty();
            RuleFor(x => x.UnitsInStock).NotEmpty();

            RuleFor(x => x.UnitPrice).NotEmpty().GreaterThan(0);
            RuleFor(x => x.UnitsInStock).GreaterThanOrEqualTo((short)0);
            RuleFor(x => x.UnitPrice).GreaterThan(10).When(x => x.CategoryId == 2);
        }
    }
}
