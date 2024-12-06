using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);    //View<==>"Controller<==>Models"
        }

        //Get
        public IActionResult Edit(int? id)   // https://localhost:7071-map-到 "/categories/edit/id(1 or 2)"; /categories/edit?id=777
        {
            var categort = CategoriesRepository.GetCategoryById(id.HasValue ? id.Value:0);    // 初始化 Category 模型並傳遞給 View，處理 id 的 null 預設值
            return View(categort);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
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
            CategoriesRepository.DeleteCategory(categoryiId);
            return RedirectToAction(nameof(Index));
        }
    }
}
