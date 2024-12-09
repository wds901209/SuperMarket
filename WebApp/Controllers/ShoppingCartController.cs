using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using System.Linq;

namespace WebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        // 用來儲存顧客的購物車資料
        public static Dictionary<int, ShoppingCart> shoppingCarts = new Dictionary<int, ShoppingCart>();

        // 查看客戶目前所選的商品(int categoryId顯示商品時正確抓取或管理對應的商品資訊)
        [HttpGet]
        public IActionResult ShoppingCart(int customerId, int categoryId)
        {
            // 檢查 customerId 是否有效
            var customer = CustomersRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            // 如果顧客尚未有購物車，則建立一個新的購物車(一開始為空)
            if (!shoppingCarts.ContainsKey(customerId))
            {
                shoppingCarts[customerId] = new ShoppingCart { CustomerId = customerId };
            }

            // 取得顧客的購物車
            var cart = shoppingCarts[customerId];

            return View(cart);
        }


        // 將商品加入購物車
        [HttpPost]
        public IActionResult AddToShoppingCart(int categoryId)
        {
            // 從 Session 中取得 customerId
            int? customerId = HttpContext.Session.GetInt32("CustomerId");

            if (customerId == null)
            {
                throw new Exception("Customer session has expired or is invalid.");
            }

            // 從 CategoriesRepository 獲取商品資料
            var category = CategoriesRepository.GetCategoryById(categoryId);
            if (category == null)
            {
                return BadRequest(new { message = "Product not found." });
            }

            // 如果顧客尚未有購物車，則建立一個新的購物車
            if (!shoppingCarts.ContainsKey(customerId.Value))
            {
                shoppingCarts[customerId.Value] = new ShoppingCart { CustomerId = customerId.Value };
            }

            var cart = shoppingCarts[customerId.Value];

            // 檢查商品是否已經在購物車中
            var existingItem = cart.Items.FirstOrDefault(item => item.CategoryId == category.CategoryId);

            if (existingItem != null)
            {
                // 如果商品已經存在，增加數量
                existingItem.Quantity++;
            }
            else
            {
                // 如果商品不在購物車中，則新增商品
                cart.Items.Add(new ShoppingCartItem
                {
                    CategoryId = category.CategoryId, // 將 CategoryId 視為商品 ID
                    Name = category.Name,
                    Price = category.Price,
                    Quantity = 1
                });
            }
            // 回到 CategoriesController 的 Index 方法 (RedirectToAction(action, controller, routeValue))
            return RedirectToAction("Index", "Categories", new { customerId = customerId.Value });
        }

    }
}
