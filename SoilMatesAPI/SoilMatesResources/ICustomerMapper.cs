using SoilMatesDB.Models;
using SoilMatesResources.Models;
using System.Collections.Generic;

namespace SoilMatesResources
{
    public interface ICustomerMapper
    {
        Customer ParseCustomer(CustomerWeb customer);
        CustomerWeb ParseCustomer(Customer cutomer);
        List<CustomerWeb> ParseCustomer(List<Customer> customer);
    }
}
