using SoilMatesDB.Models;
using SoilMatesResources.Models;
using System.Collections.Generic;

namespace SoilMatesResources
{
    /// <summary>
    /// Maps customer from web resource to data model
    /// </summary>
    public interface ICustomerMapper
    {
        Customer ParseCustomer(CustomerResource customer);
        CustomerResource ParseCustomer(Customer cutomer);
        List<CustomerResource> ParseCustomer(List<Customer> customer);
    }
}
