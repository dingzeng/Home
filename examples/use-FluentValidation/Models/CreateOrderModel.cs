using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace use_FluentValidation.Models
{
    public class CreateOrderModel
    {
        public int UserId { get; set; }

        public string PhoneNo { get; set; }

        public List<OrderItem> Items { get; set; }

        public Address Address { get; set; }
    }

    public class OrderItem
    {
        public int ProductId { get; set; }

        public int Num { get; set; }

        public decimal Price { get; set; }
    }

    public class Address
    {
        public string City { get; set; }

        public string ZipCode { get; set; }
    }
}
