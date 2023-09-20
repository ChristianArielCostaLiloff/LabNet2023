using Practica3_EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace Practica3_EF.Logic
{
    public class CustomersLogic : BaseLogic, IABMLogic<Customers>
    {
        public CustomersLogic() : base() { }

        public void CreateOne(Customers newCustomer)
        {
            if (RecordExists(newCustomer.CustomerID))
            {
                throw new Exception("Ya existe un cliente con el id introducido");
            }
            if (newCustomer.CustomerID == null || newCustomer.CompanyName == null)
            {
                throw new Exception("Los campos id y nombre de compañia son obligatorios");
            }
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
            var record = (from cust in context.Customers
                          where cust.CustomerID.TrimEnd() == id.TrimEnd()
                          select cust).FirstOrDefault();
            return record != null;
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
            if (!RecordExists(customer.CustomerID))
            {
                throw new Exception("No existe cliente asociado al id introducido");
            }
            if (customer.CustomerID == null || customer.CompanyName == null)
            {
                throw new Exception("Los campos id y nombre de compañia son obligatorios");
            }
            try
            {
                customerToUpdate =
                    (from cust in context.Customers
                     where cust.CustomerID.TrimEnd() == customer.CustomerID.TrimEnd()
                     select cust).FirstOrDefault();

                customerToUpdate.CompanyName = customer.CompanyName;
                customerToUpdate.ContactName = customer.ContactName;
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
            if (!RecordExists(id))
            {
                throw new Exception("No existe cliente asociado al id introducido");
            }
            try
            {
                Customers customerToDelete =
                    (from cust in context.Customers
                     where cust.CustomerID.TrimEnd() == id.TrimEnd()
                     select cust).FirstOrDefault();
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
