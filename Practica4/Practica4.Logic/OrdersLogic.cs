using Practica4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.Logic
{
    public class OrdersLogic : BaseLogic
    {   
        public OrdersLogic() : base() { }
        public List<Orders> JoinCustomersRegionWAOrdersDateGreaterThan01011997()
        {
            DateTime dateTime = new DateTime(1997, 01, 01);
            var query = (from customer in context.Customers
                         join orders in context.Orders
                             on customer.CustomerID equals orders.CustomerID into joined
                         from j in joined
                         where customer.Region == "WA" && j.OrderDate > dateTime
                         orderby j.OrderID
                         select j).ToList();
            return query;
        }
    }
}
