using SoilMatesResources.Models;
using System;
using System.Collections.Generic;
using System.Text;
using SoilMatesDB.Models;

namespace SoilMatesResources
{
    public interface IProductMapper
    {
        Product ParseProduct(ProductResource product);
        ProductResource ParseProduct(Product product);
        List<ProductResource> ParseProduct(List<Product> product);
    }
}
