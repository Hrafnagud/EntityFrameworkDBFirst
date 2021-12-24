using EntityFrameworkDBFirst_BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkDBFirstDAL;

namespace EntityFrameworkDBFirst_BLL
{
    public class ProductManager
    {
        //Global
        NORTHWNDEntities myDBContext = new NORTHWNDEntities();

        public List<ProductViewModel> BringAllProducts()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            var data = myDBContext.Products;

            foreach (var item in data)
            {
                ProductViewModel p = new ProductViewModel()
                {
                    CategoryID = item.CategoryID,
                    ProductID = item.ProductID,
                    UnitPrice = item.UnitPrice,
                    UnitsInStock = item.UnitsInStock,
                    Discontinued = item.Discontinued
                };
            }
            return products;
        }
        
    }
}
