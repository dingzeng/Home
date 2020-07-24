using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using use_FluentValidation.Models;
using use_FluentValidation.Validator;

namespace use_FluentValidation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        public CreateOrderModel CreateOrder(CreateOrderModel model)
        {
            var validator = new CreateOrderValidator();
            var validateResult = validator.Validate(model);

            if (validateResult.IsValid)
            {
                return model;
            }

            return null;
        }
    }
}
