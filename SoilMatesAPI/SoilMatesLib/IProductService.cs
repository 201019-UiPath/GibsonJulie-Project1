using SoilMatesDB.Models;
using System.Collections.Generic;

namespace SoilMatesLib
{
    /// <summary>
    /// Product service interface
    /// </summary>
    public interface IProductService
    {
        void AddNewProduct(string name, decimal price, string description);
        void AddProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProduct(int id);
        Product GetProduct(string name);
        void RemoveProduct(Product product);
        void SaveChanges();
    }
}