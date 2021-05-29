using FluentValidation;
using lab2.Data;
using lab2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Validators
{
    public class ExpenseValidator : AbstractValidator<ExpensesViewModel>
    {
        private readonly ApplicationDbContext _context;
        public ExpenseValidator(ApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.Description).MinimumLength(10);
            RuleFor(x => x.Sum).InclusiveBetween(10, Double.MaxValue);
            RuleFor(x => x.Location).MinimumLength(3);

            RuleFor(x => x.Type).Custom((prop, validationContext) =>
            {
                var instance = validationContext.InstanceToValidate;
                int commentsForTypeCount = _context.Comments.Where(c => c.Expense.Type == instance.Type).Count();
                if (commentsForTypeCount > 10)
                {
                    validationContext.AddFailure($"Cannot add a product with type {instance.Type} because that type has more than 10 comments: it has {commentsForTypeCount}.");
                }
            });

            RuleFor(x => x).Custom((prop, validationContext) =>
            {
                var instance = validationContext.InstanceToValidate;
                if(instance.Type == Models.Types.electronics)
                {
                    if(instance.Sum < 20.0)
                    {
                        validationContext.AddFailure($"Canoot add a product with type {instance.Type} because the price is < 20: it is {instance.Sum}.");
                    }
                }
            });
        }
    }
}
