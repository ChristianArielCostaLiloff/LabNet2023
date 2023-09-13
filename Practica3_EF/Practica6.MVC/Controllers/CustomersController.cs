using Practica3_EF.Entities;
using Practica3_EF.Logic;
using Practica6.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Practica6.MVC.Controllers
{
    public class CustomersController : Controller
    {
        CustomersLogic customersLogic = new CustomersLogic();
        // GET: Customers
        public ActionResult Index()
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

            return View(customersViews);
        }
        public ActionResult Create() { return View(); }
        [HttpPost]
        public ActionResult Create(CustomersView customersView)
        {
            try
            {
                if (!customersLogic.RecordExists(customersView.Id))
                {
                    if (ModelState.IsValid)
                    {

                        Customers newCustomer = new Customers
                        {
                            CustomerID = customersView.Id,
                            CompanyName = customersView.CompanyName,
                            ContactName = customersView.ConctactName,
                            City = customersView.City,
                            Phone = customersView.Phone
                        };
                        customersLogic.CreateOne(newCustomer);
                        return RedirectToAction("Index", "Customers");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "El id de cliente ya existe");
                    return View();
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string id)
        {
            try
            {
                customersLogic.DeleteOne(id);
                return RedirectToAction("Index", "Customers");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Update(CustomersView customersView)
        {
            return View(customersView);
        }
        [HttpPost]
        public ActionResult UpdateOne(CustomersView customersView)
        {
            customersLogic.UpdateOne(new DtoCustomer(
                customersView.Id,
                customersView.CompanyName,
                customersView.ConctactName,
                customersView.City,
                customersView.Phone));

            return RedirectToAction("Index");
        }
    }
}