using System.Collections.Generic;

namespace UnityPoc.Models
{
    public class ProductsRepository : IProductsRepository
    {
        public IEnumerable<Product> Get()
        {
            return new[] {new Product()};
        }
    }
}