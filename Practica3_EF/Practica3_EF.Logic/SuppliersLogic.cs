using Practica3_EF.Entities;
using System;
using System.Collections.Generic;
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
            context.SaveChanges();
        }

        public List<Suppliers> ReadAll()
        {
            return context.Suppliers.ToList();
        }
        public Suppliers UpdateOne(Suppliers supplier)
        {
            var supplierToUpdate = context.Suppliers.Find(supplier.SupplierID);
            supplierToUpdate.CompanyName = supplier.CompanyName;
            context.SaveChanges();
            return supplierToUpdate;
        }

        public Suppliers DeleteOne(Suppliers supplier)
        {
            var supplierToDelete = context.Suppliers.Find(supplier.SupplierID);
            context.Suppliers.Remove(supplierToDelete);
            context.SaveChanges();
            return supplierToDelete;
        }
    }
}
