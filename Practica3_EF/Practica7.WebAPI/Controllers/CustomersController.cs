using Practica3_EF.Entities;
using Practica3_EF.Logic;
using Practica7.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Linq;
using System.Security.Policy;

namespace Practica7.WebAPI.Controllers
{
    public class CustomersController : ApiController
    {
        CustomersLogic customersLogic = new CustomersLogic();
        public IHttpActionResult GetCustomers()
        {
            try
            {
                List<Customers> customers = customersLogic.ReadAll();
                List<CustomersView> customersViews = customers.Select(customer => new CustomersView
                {
                    Id = customer.CustomerID,
                    CompanyName = customer.CompanyName,
                    ConctactName = customer.ContactName,
                    City = customer.City,
                    Phone = customer.Phone
                }).ToList();
                return Ok(customersViews);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
        public IHttpActionResult PostCreate([FromBody] CustomersView customer)
        {
            try
            {
                Customers newCustomer = new Customers
                {
                    CustomerID = customer.Id,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ConctactName,
                    City = customer.City,
                    Phone = customer.Phone
                };
                customersLogic.CreateOne(newCustomer);
                return Content(HttpStatusCode.Created, customer);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult PutCustomer([FromBody] CustomersView customer)
        {
            try
            {
                DtoCustomer customerToUpdate = new DtoCustomer(
                    customer.Id,
                    customer.CompanyName,
                    customer.ConctactName,
                    customer.City,
                    customer.Phone
                    );
                customersLogic.UpdateOne(customerToUpdate);
                return Ok(customerToUpdate);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
        public IHttpActionResult DeleteCustomer([FromUri] string id)
        {
            try
            {
                customersLogic.DeleteOne(id);
                return Ok("Eliminado el cliente con id: " + id);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
