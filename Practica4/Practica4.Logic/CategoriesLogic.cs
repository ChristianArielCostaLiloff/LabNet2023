using Practica4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.Logic
{
    public class CategoriesLogic : BaseLogic
    {
        public CategoriesLogic() : base() { }

        public List<Categories> CategoriesInProducts()
        {
            var query = (from product in context.Products
                         join category in context.Categories
                            on product.CategoryID equals category.CategoryID into joined
                         from j in joined
                         select j).ToList().Distinct().ToList();
            return query;
        }
    }
}
