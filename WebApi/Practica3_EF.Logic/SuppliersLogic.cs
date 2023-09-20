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
    public class SuppliersLogic : BaseLogic, IABMLogic<Suppliers>
    {
        public SuppliersLogic() : base() { }

        public void CreateOne(Suppliers newSupplier)
        {
            context.Suppliers.Add(newSupplier);
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

        public List<Suppliers> ReadAll()
        {
            List<Suppliers> suppliersList = new List<Suppliers>();
            try
            {
                suppliersList = context.Suppliers.ToList();
            }
            catch (Exception ex)
            {
                LogicExceptions.ExceptionMessage(ex);
            }
            return suppliersList;
        }
        public Suppliers UpdateOne(Suppliers supplier)
        {
            Suppliers supplierToUpdate = supplier;
            try
            {
                supplierToUpdate = context.Suppliers.Single(p => p.SupplierID == supplier.SupplierID);
                supplierToUpdate.CompanyName = supplier.CompanyName;
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
            return supplierToUpdate;
        }

        public Suppliers DeleteOne(Suppliers supplier)
        {
            Suppliers supplierToDelete = supplier;
            try
            {
                supplierToDelete = context.Suppliers.Single(p => p.SupplierID == supplier.SupplierID);
                context.Suppliers.Remove(supplierToDelete);
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
            return supplierToDelete;
        }
    }
}
