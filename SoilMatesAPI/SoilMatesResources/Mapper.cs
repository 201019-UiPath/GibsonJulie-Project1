using SoilMatesDB.Models;
using SoilMatesResources.Models;
using System;
using System.Collections.Generic;

namespace SoilMatesResources
{
    public class Mapper : ICustomerMapper
    {
        public Customer ParseCustomer(CustomerWeb customer)
        {
            return new Customer()
            {
                Name = customer.Name,
                Email = customer.Email,
                Password = customer.Password
            };
        }

        public CustomerWeb ParseCustomer(Customer customer)
        {
            return new CustomerWeb()
            {
                Email = customer.Email,
                Name = customer.Name,
                Password = customer.Password,
            };
        }

        public List<CustomerWeb> ParseCustomer(List<Customer> customer)
        {
            List<CustomerWeb> allCustomers = new List<CustomerWeb>();
            foreach(var c in customer)
            {
                allCustomers.Add(ParseCustomer(c));
            }
            return allCustomers;
        }
    }
}
