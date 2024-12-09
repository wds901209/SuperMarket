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
            if (id <= 0)
            {
                return null; // 或者拋出一個自定義的例外
            }

            // 查詢客戶
            return _customers.FirstOrDefault(x => x.Id == id);
        }

        public static string GetCustomerNameById(int id)
        {
            // 檢查 ID 是否有效
            if (id <= 0)
            {
                return null; // 或者你可以選擇返回一個預設值，比如 "Unknown"
            }

            // 查詢並返回客戶名稱
            var customer = _customers.FirstOrDefault(x => x.Id == id);

            // 如果找不到該客戶，返回預設值
            return customer?.CustomerName ?? "Unknown";
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

