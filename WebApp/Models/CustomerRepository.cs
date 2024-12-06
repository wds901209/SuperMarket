using WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Models
{
    public class CustomersRepository
    {

        private static List<Customer> _customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Andy", Address = "新竹市東區", Phone = "0981123456", Email = "andy@gmail.com" },
            new Customer { Id = 2, Name = "Bob", Address = "新竹市西區", Phone = "0981234567", Email = "bob@gmail.com" }
        };
        
        public static List<Customer> GetCustomer() => _customers;

        public static Customer GetCustomerById(int id)
        {
            var customer = _customers.FirstOrDefault(x => x.Id == id);
            if(customer != null)
            {
                return new Customer
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Address = customer.Address,
                    Phone = customer.Phone,
                    Email = customer.Email,                 
                };
            }
            return null;
        }

        public void Add(Customer customer)
        {
            _customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            var existing = _customers.FirstOrDefault(c => c.Id == customer.Id);
            if (existing != null)
            {
                existing.Name = customer.Name;
                existing.Address = customer.Address;
                existing.Phone = customer.Phone;
                existing.Email = customer.Email;
            }
        }

        public void Delete(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                _customers.Remove(customer);
            }
        }
    }
}

