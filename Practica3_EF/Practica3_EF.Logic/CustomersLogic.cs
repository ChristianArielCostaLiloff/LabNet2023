using Practica3_EF.Data;
using Practica3_EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                LogicExceptions.DbUpdateExceptionMessage(ex);
            }
            catch (DbEntityValidationException ex)
            {
                LogicExceptions.DbEntityValidationExceptionMessage(ex);
            }
            catch (Exception ex)
            {
                LogicExceptions.ExceptionMessage(ex);
            }
        }

        public List<Customers> ReadAll()
        {
            List<Customers> customersList = new List<Customers>();
            try
            {
                customersList = context.Customers.ToList();
            }
            catch (Exception ex)
            {
                LogicExceptions.ExceptionMessage(ex);
            }
            return customersList;
        }
        public bool RecordExists(string id)
        {
            return context.Customers.Any(customer => customer.CustomerID == id);
        }

        public Customers UpdateOne(Customers customer)
        {
            Customers customerToUpdate = customer;
            try
            {
                customerToUpdate = context.Customers.Single(p => p.CustomerID == customer.CustomerID);
                customerToUpdate.CompanyName = customer.CompanyName;
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                LogicExceptions.DbUpdateExceptionMessage(ex);
            }
            catch (DbEntityValidationException ex)
            {
                LogicExceptions.DbEntityValidationExceptionMessage(ex);
            }
            catch (NullReferenceException ex)
            {
                LogicExceptions.NullReferenceExceptionMessage(ex);
            }
            catch (Exception ex)
            {
                LogicExceptions.ExceptionMessage(ex);
            }
            return customerToUpdate;
        }
        public void UpdateOne(DtoCustomer customer)
        {
            Customers customerToUpdate;
            try
            {
                customerToUpdate = context.Customers.Single(p => p.CustomerID == customer.CustomerID);
                customerToUpdate.CustomerID = customer.CustomerID;
                customerToUpdate.CompanyName = customer.CompanyName;
                customerToUpdate.ContactName = customer.ConctactName;
                customerToUpdate.City = customer.City;
                customerToUpdate.Phone = customer.Phone;
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                LogicExceptions.DbUpdateExceptionMessage(ex);
            }
            catch (DbEntityValidationException ex)
            {
                LogicExceptions.DbEntityValidationExceptionMessage(ex);
            }
            catch (NullReferenceException ex)
            {
                LogicExceptions.NullReferenceExceptionMessage(ex);
            }
            catch (Exception ex)
            {
                LogicExceptions.ExceptionMessage(ex);
            }
        }

        public Customers DeleteOne(Customers customer)
        {
            Customers customerToDelete = customer;
            try
            {
                customerToDelete = context.Customers.Single(p => p.CustomerID == customer.CustomerID);
                context.Customers.Remove(customerToDelete);
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                LogicExceptions.DbUpdateExceptionMessage(ex);
            }
            catch (DbEntityValidationException ex)
            {
                LogicExceptions.DbEntityValidationExceptionMessage(ex);
            }
            catch (NullReferenceException ex)
            {
                LogicExceptions.NullReferenceExceptionMessage(ex);
            }
            catch (Exception ex)
            {
                LogicExceptions.ExceptionMessage(ex);
            }
            return customerToDelete;
        }
        public void DeleteOne(string id)
        {
            try
            {
                Customers customerToDelete = context.Customers.Find(id);
                context.Customers.Remove(customerToDelete);
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                LogicExceptions.DbUpdateExceptionMessage(ex);
            }
            catch (DbEntityValidationException ex)
            {
                LogicExceptions.DbEntityValidationExceptionMessage(ex);
            }
            catch (NullReferenceException ex)
            {
                LogicExceptions.NullReferenceExceptionMessage(ex);
            }
            catch (Exception ex)
            {
                LogicExceptions.ExceptionMessage(ex);
            }
        }
    }
}
