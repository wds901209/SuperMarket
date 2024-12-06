using Microsoft.AspNetCore.Mvc;
using WebApp.Models; // 如果 Customer 類別是位於這個命名空間

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var customers = CustomersRepository.GetCustomer();
            return View(customers);    //View<==>"Controller<==>Models"
        }


        // 顯示單一客戶的詳細資訊
        public IActionResult Details(int id)
        {
            // 根據 Id 查找客戶
            var customers = CustomersRepository.GetCustomer();

            if (customers == null)
            {
                return NotFound(); // 如果找不到該客戶，返回 404
            }

            return View(customers); // 將客戶資料傳遞給 Details 視圖
        }
        public IActionResult Edit(int? id)   // https://localhost:7071-map-到 "/categories/edit/id(1 or 2)"; /categories/edit?id=777
        {
            var categort = CategoriesRepository.GetCategoryById(id.HasValue ? id.Value : 0);    // 初始化 Category 模型並傳遞給 View，處理 id 的 null 預設值
            return View(categort);
        }
    }
}
