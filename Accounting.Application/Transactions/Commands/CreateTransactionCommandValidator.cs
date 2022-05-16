using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Application.Transactions.Commands
{
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
}
