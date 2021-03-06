
using System.Collections.Generic;
using System.Threading.Tasks;
using SoilMatesDB.Models;

namespace SoilMatesLib
{
    /// <summary>
    /// Customer interface that defines behavior of customers
    /// </summary>
    public interface ICustomerService
    {
        void AddCustomer(Customer newCustomer);
        List<Customer> GetAllCustomers();
        Customer GetCustomerByEmail(string email);
        Customer GetCustomerByLogin(string password, string email);
        void SaveChanges();
        void SignUpCustomer(string name, string email, string password);
    }
}