using SoilMatesDB.Models;
using SoilMatesResources.Models;
using System.Collections.Generic;

namespace SoilMatesResources
{
    public interface ICustomerMapper
    {
        Customer ParseCustomer(CustomerResource customer);
        CustomerResource ParseCustomer(Customer cutomer);
        List<CustomerResource> ParseCustomer(List<Customer> customer);
    }
}
