using FluentValidation;

namespace Northwind.Business.Utilities;

public static class ValidationTool
{
    public static void Validate(IValidator validator, object entity)
    {
        var validationContext = new ValidationContext<object>(entity);
        var result = validator.Validate(validationContext);
        if (result.Errors.Count > 0)
        {
            throw new ValidationException(result.Errors.ToString());
        }
    }
}