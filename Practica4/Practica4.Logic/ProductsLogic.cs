using Practica4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.Logic
{
    public class ProductsLogic : BaseLogic
    {
        public ProductsLogic() : base() { }

        public List<Products> ProductsWithoutStock()
        {
            var query = context.Products.Where(p => p.UnitsInStock == 0).ToList();
            return query;
        }

        public List<Products> ProductsWithStockAndPriceMoreThan3()
        {
            var query = context.Products
                .Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3)
                .ToList();
            return query;
        }
    }
}
