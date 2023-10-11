using FluentValidation;
using SaleSeeker_Api.Models.Stock;

namespace SaleSeeker_Api.Utils.Validators;

public class UpdateStockValidator : AbstractValidator<StockItemUpdate>
{
    public UpdateStockValidator()
    {
        RuleFor(p => p.Images).NotNull().NotEmpty();
        RuleFor(p => p.Name).NotNull().NotEmpty();
        RuleFor(p => p.Description).NotNull().NotEmpty();
        RuleFor(p => p.Variant).NotNull().NotEmpty();
        RuleFor(p => p.PricePerUnit).GreaterThan(0);
    }
}
public class AddStockValidator : AbstractValidator<StockItemAdd>
{
    public AddStockValidator()
    {
        RuleFor(p => p.AvailableQuantity).GreaterThan(0);
        RuleFor(p => p.IsActive).Equals(true);
        RuleFor(p => p.Images).NotNull().NotEmpty();
        RuleFor(p => p.Name).NotNull().NotEmpty();
        RuleFor(p => p.Description).NotNull().NotEmpty();
        RuleFor(p => p.Variant).NotNull().NotEmpty();
        RuleFor(p => p.PricePerUnit).GreaterThan(0);
    }
}