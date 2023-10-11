using FluentValidation;
using SaleSeeker_Api.Models.CartItem;

namespace SaleSeeker_Api.Utils.Validators;

public class CartValidator : AbstractValidator<CartItemAdd>
{
    public CartValidator()
    {
        RuleFor(c => c.UserId);
            

        //RuleFor(c => c.Balance).GreaterThanOrEqualTo(0);

        //RuleFor(c => c.IsCheckedOut).Equal(false);

        //RuleForEach(c => c.Items)
        //    .SetValidator(new StockValidator())
        //    .When(c => c.Items.Any());
    }

    

}
public class CartUpdateValidator : AbstractValidator<CartItemUpdate>
{
    public CartUpdateValidator()
    {
        // RuleFor(c => c.UserId)
        //     .Must(BeRegisteredUser).WithMessage("User is not registered in the system.");
        //
        // RuleFor(c => c.Balance).GreaterThanOrEqualTo(0);
        //
        // RuleFor(c => c.IsCheckedOut).Equal(false);

        //RuleForEach(c => c.Items)
        //    .SetValidator(new StockValidator())
        //    .When(c => c.Items.Any());
    }

    private bool BeRegisteredUser(int userId)
    {
        // TODO : Impliment
        return true;
    }

}