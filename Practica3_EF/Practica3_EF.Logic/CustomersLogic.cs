using Practica3_EF.Data;
using Practica3_EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3_EF.Logic
{
    public class CustomersLogic : BaseLogic, IABMLogic<Customers>
    {
        public CustomersLogic() : base() { }

        public void CreateOne(Customers newCustomer)
        {
            context.Customers.Add(newCustomer);
            context.SaveChanges();
        }

        public List<Customers> ReadAll()
        {
            return context.Customers.ToList();
        }

        public Customers UpdateOne(Customers customer)
        {
            var customerToUpdate = context.Customers.Find(customer.CustomerID);
            customerToUpdate.CompanyName = customer.CompanyName;
            context.SaveChanges();
            return customerToUpdate;
        }

        public Customers DeleteOne(Customers customer)
        {
            var customerToDelete = context.Customers.Find(customer.CustomerID);
            context.Customers.Remove(customerToDelete);
            context.SaveChanges();
            return customerToDelete;
        }
    }
}
