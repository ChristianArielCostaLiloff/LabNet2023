using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3_EF.Logic
{
    public class DtoCustomer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        public DtoCustomer(string customerId, string companyName, string contactName, string city, string phone)
        {
            this.CustomerID = customerId;
            this.CompanyName = companyName;
            this.ContactName = contactName;
            this.City = city;
            this.Phone = phone;
        }
    }
}
