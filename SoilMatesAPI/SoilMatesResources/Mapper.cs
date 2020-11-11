using SoilMatesDB.Models;
using SoilMatesResources.Models;
using System;
using System.Collections.Generic;

namespace SoilMatesResources
{
    public class Mapper : ICustomerMapper, IManagerMapper
    {
        public Customer ParseCustomer(CustomerResource customer)
        {
            return new Customer()
            {
                Name = customer.Name,
                Email = customer.Email,
                Password = customer.Password
            };
        }

        public CustomerResource ParseCustomer(Customer customer)
        {
            return new CustomerResource()
            {
                Email = customer.Email,
                Name = customer.Name,
                Password = customer.Password,
            };
        }

        public List<CustomerResource> ParseCustomer(List<Customer> customer)
        {
            List<CustomerResource> allCustomers = new List<CustomerResource>();
            foreach(var c in customer)
            {
                allCustomers.Add(ParseCustomer(c));
            }
            return allCustomers;
        }

        public Manager ParseManager(ManagerResource manager)
        {
            return new Manager()
            {
                Name = manager.Name,
                Email = manager.Email,
                Password = manager.Password
            };
        }

        public ManagerResource ParseManager(Manager manager)
        {
            return new ManagerResource()
            {
                Name = manager.Name,
                Email = manager.Email,
                Password = manager.Password,
            };
        }

        public List<ManagerResource> ParseManager(List<Manager> manager)
        {
            List<ManagerResource> allManagers = new List<ManagerResource>();
            foreach (var m in manager)
            {
                allManagers.Add(ParseManager(m));
            }
            return allManagers;
        }

       
    }
}
