using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index(int id)
        {
            var customer = CustomersRepository.GetCustomerById(id);
            return View(customer);
        }

        //public IActionResult Index1(int customerId)
        //{
        //    var customer = CustomersRepository.GetCustomerById(customerId);
        //    string customerName = customer?.Name ?? "Unknown";

        //    var categories = CategoriesRepository.GetCategories();

        //    // 使用 ViewBag 傳遞 Customer 的名字到 View
        //    //ViewBag.CustomerId = customer.Id;
        //    //ViewBag.CustomerName = customer.Name;

        //    return View(categories);    //View<==>"Controller<==>Models"
        //}
    }
}
