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
        public List<Products> ProductsOrderByName()
        {
            var query = (from product in context.Products
                         orderby product.ProductName
                         select product)
                         .ToList();

            return query;
        }
        public List<Products> ProductsOrderByStockDesc()
        {
            var query = (from product in context.Products
                         orderby product.UnitsInStock descending
                         select product)
                         .ToList();

            return query;
        }
        public List<Products> ReadFirst()
        {
            var query = context.Products.ToList().Take(1).ToList();
            return query;
        }
    }
}
