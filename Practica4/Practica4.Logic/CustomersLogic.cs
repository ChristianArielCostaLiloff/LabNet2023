using Practica4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.Logic
{
    public class CustomersLogic : BaseLogic
    {
        public CustomersLogic() : base() { }

        public Customers ReadFirst()
        {
            var query = context.Customers.FirstOrDefault();
            return query;
        }
        public List<Customers> ReadCustomersFromWA()
        {
            var query = (from customer in context.Customers
                         where customer.Region == "WA"
                         select customer)
                         .ToList();
            return query;
        }
        public Customers ReadId789FirstOrNull()
        {
            var query = context.Customers.FirstOrDefault(customer => customer.CustomerID.Equals("789"));
            return query;
        }
        public List<Customers> ReadAll()
        {
            var query = context.Customers.ToList();
            return query;
        }
        public List<Customers> ReadFirst3()
        {
            var query = (from customer in context.Customers
                         where customer.Region == "WA"
                         select customer)
                         .Take(3)
                         .ToList();
            return query;
        }
        public List<Customers> ReadCostumersWithOrderCuantity()
        {
            //var query = (from customer in context.Customers
            //             join order in context.Orders on customer.CustomerID equals order.CustomerID
            //             into joined
            //             from element in joined.DefaultIfEmpty()
            //             orderby customer.CustomerID
            //             select new
            //             {
            //                 customer.CustomerID,
            //                 customer.CompanyName,
            //                 customer.Country,
            //                 OrderCuantity = customer.Orders.Count()
            //             }).ToList();
            var query = context.Customers.ToList();
            return query;
        }

    }
}
