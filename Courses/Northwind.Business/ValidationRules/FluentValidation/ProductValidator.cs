using FluentValidation;
using Northwind.Entities.Concrete;

namespace Northwind.Business.ValidationRules.FluentValidation;

public class ProductValidator: AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.product_name).NotEmpty();
        RuleFor(p => p.category_id).NotEmpty();
        RuleFor(p=> p.unit_price).NotEmpty();
        RuleFor(p => p.quantity_per_unit).NotEmpty();
        RuleFor(p => p.units_in_stock);

        RuleFor(p => p.unit_price).GreaterThan(0);
        RuleFor(p => p.units_in_stock).GreaterThan((short)0);
        RuleFor(p => p.unit_price).GreaterThan((short)10).When(p=>p.category_id == 2);

        RuleFor(p => p.product_name).Must(StartWith);
    }

    private bool StartWith(string arg)
    {
        return arg.StartsWith(arg);
    }
}