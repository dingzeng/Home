using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using use_FluentValidation.Models;

namespace use_FluentValidation.Validator
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderModel>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.PhoneNo).NotNull();
            RuleForEach(x => x.Items).ChildRules(order =>
            {
                order.RuleFor(o => o.ProductId).NotEmpty();
                order.RuleFor(o => o.Num).NotEmpty().GreaterThan(0);
                order.RuleFor(o => o.Price).NotEmpty().GreaterThan(0);
            });
            RuleFor(x => x.Address).SetValidator(new OrderAddressValidator());
        }
    }

    public class OrderAddressValidator : AbstractValidator<Address>
    {
        public OrderAddressValidator()
        {
            RuleFor(x => x.City).NotNull();
            RuleFor(x => x.ZipCode).NotNull();
        }
    }
}
