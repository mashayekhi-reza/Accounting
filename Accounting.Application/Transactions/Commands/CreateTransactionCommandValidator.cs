using FluentValidation;

namespace Accounting.Application.Transactions.Commands;

public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
{
    public CreateTransactionCommandValidator()
    {
        RuleFor(v => v.Transaction.Amount)
            .GreaterThan(0);

        RuleFor(v => v.Transaction.Account.Name)
            .Length(1, 100);
    }
}
