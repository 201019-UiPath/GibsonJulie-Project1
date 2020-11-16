using SoilMatesResources.Models;
using System;
using System.Collections.Generic;
using System.Text;
using SoilMatesDB.Models;

namespace SoilMatesResources
{
    /// <summary>
    /// Maps Products from data models and web resource models
    /// </summary>
    public interface IProductMapper
    {
        Product ParseProduct(ProductResource product);
        ProductResource ParseProduct(Product product);
        List<ProductResource> ParseProduct(List<Product> product);
    }
}
