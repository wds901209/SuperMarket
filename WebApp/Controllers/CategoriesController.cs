using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        // 選擇customer後進入的畫面
        public IActionResult Index(int customerId)
        {
            // 嘗試從 Repository 中取得 customer
            var customer = CustomersRepository.GetCustomerById(customerId);

            if (customer == null)
            {
                return View(customer);
            }

            // 將 customerId 存入 Session
            HttpContext.Session.SetInt32("CustomerId", customer.Id);

            // 正常取得客戶資訊
            ViewBag.CustomerId = customer.Id;
            ViewBag.CustomerName = customer.Name;

            // 取得商品列表
            var categories = CategoriesRepository.GetCategories();

            return View(categories);
        }



        //Get 進入修改商品畫面
        public IActionResult Edit(int? id)   // https://localhost:7071-map-到 "/categories/edit/id(1 or 2)"; /categories/edit?id=777
        {
            var categort = CategoriesRepository.GetCategoryById(id.HasValue ? id.Value : 0);    // 初始化 Category 模型並傳遞給 View，處理 id 的 null 預設值
            return View(categort);
        }

        // 按下儲存並且回到菜單畫面且完成新增
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            // 從 Session 取得 customerId
            var customerId = HttpContext.Session.GetInt32("CustomerId") ?? 0; // 如果 Session 中沒有 customerId，則預設為 0

            if (ModelState.IsValid)
            {
                // 更新 Category
                CategoriesRepository.UpdateCategory(category.CategoryId, category);

                // 修改完成後，重定向回顧客頁面，並帶上顧客 ID
                return RedirectToAction("Index", "Categories", new { customerId = customerId });
            }

            // 如果模型無效，保持顧客 ID 並返回編輯頁面
            ViewBag.CustomerId = customerId;
            return View(category);  // 重新返回 Category 頁面
        }




        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }


        public IActionResult Delete(int categoryiId)
        {
            // 從 Session 取得 customerId
            var customerId = HttpContext.Session.GetInt32("CustomerId") ?? 0; // 如果 Session 中沒有 customerId，則預設為 0

            CategoriesRepository.DeleteCategory(categoryiId);
            // 修改完成後，重定向回顧客頁面，並帶上顧客 ID
            return RedirectToAction("Index", "Categories", new { customerId = customerId });       
        }
    }
}