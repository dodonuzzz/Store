using System;
using System.Collections.Generic;
using Yeniden_Chum_Bucket.Models;
using System.Linq;

namespace Yeniden_Chum_Bucket.Controllers
{
    public class ProductProvider
    {
        public IEnumerable<Product> GetProductsFromDatabase()
        {
            using (var DbContext = new ProductContext()) 
            {
                var products = DbContext.Products.ToList(); // Verileri çekme işlemi
                return products;
            }
        }
        public readonly Product product;

        public Product GetProduct()
        {
            // Ürünü getirme veya oluşturma işlemleri burada gerçekleştirilir
            // Örneğin, bir veritabanından ürün bilgilerini çekmek için kodlar eklenir.

            // Ürün nesnesi döndürülür
            return product;
        }
    }

}