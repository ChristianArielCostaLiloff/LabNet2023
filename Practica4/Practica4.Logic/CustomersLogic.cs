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
                         select customer).ToList();
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
    }
}
