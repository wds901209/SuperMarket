using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using System.Linq;

namespace WebApp.Controllers
{
    public class InvoiceController : Controller
    {
        // 生成發票頁面
        public IActionResult CheckOut()
        {
            // 從 Session 中取得 customerId
            int? customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
            {
                return Unauthorized("Customer is not logged in.");
            }

            // 檢查是否有購物車資料
            if (!ShoppingCartController.shoppingCarts.ContainsKey(customerId.Value))
            {
                return NotFound("Shopping cart not found for this customer.");
            }

            // 取得購物車資料
            var cart = ShoppingCartController.shoppingCarts[customerId.Value];

            // 建立發票
            var invoice = new Invoice
            {
                CustomerId = customerId.Value,
                InvoiceDate = DateTime.Now,
                Items = cart.Items, // 從購物車複製商品資料
                TotalAmount = cart.Items.Sum(item => item.Price * item.Quantity),
                InvoiceNumber = Guid.NewGuid().ToString().Substring(0, 8) // 隨機生成發票號碼
            };

            // 使用 ViewBag 傳遞 CustomerName
            var customerName = CustomersRepository.GetCustomerNameById((int)customerId);
            ViewBag.CustomerName = customerName;

            // 將發票傳遞給 View
            return View(invoice);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
