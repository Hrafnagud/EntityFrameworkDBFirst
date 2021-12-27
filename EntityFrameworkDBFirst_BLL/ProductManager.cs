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
                    Discontinued = item.Discontinued,
                    UnitsOnOrder = item.UnitsOnOrder,
                    ReorderLevel = item.ReorderLevel,
                    SupplierID = item.SupplierID,
                    ProductName = item.ProductName,
                    QuantityPerUnit = item.QuantityPerUnit
                };
                //CategoryName
                //First approach
                p.CategoryName = item.Category.CategoryName;
                //Second Approach
                //p.CategoryName = myDBContext.Categories.FirstOrDefault(x => x.CategoryID == item.CategoryID)?.CategoryName;
                products.Add(p);
            }
            return products;
        }

        public bool AddNewProduct(ProductViewModel p)
        {
            bool result = false;
            Product newProduct = new Product
            {
                ProductName = p.ProductName,
                Discontinued = p.Discontinued,
                CategoryID = p.CategoryID
            };

            myDBContext.Products.Add(newProduct);
            int affectedRows = myDBContext.SaveChanges();
            if (affectedRows > 0)
            {
                result = true;
            }

            return result;
        }

    }
}
