using System.Collections.Generic;

namespace UnityPoc.Models
{
    public interface IProductsRepository
    {
        IEnumerable<Product> Get();
    }
}