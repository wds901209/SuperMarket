namespace WebApp.Models
{
    // 靜態類別作為模擬資料庫的資料存取層 (Repository Pattern)
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category {CategoryId = 1, Name = "Beverage", Description = "Beverage"},
            new Category {CategoryId = 2, Name = "Bakery", Description = "Bakery" },
            new Category {CategoryId = 3, Name = "Meat", Description = "Meat" }
        };

        // Create資料，並自動分配唯一的 CategoryId
        public static void AddCategory(Category category)   
        {
            var maxId = _categories.Max(x => x.CategoryId);
            category.CategoryId = maxId +1;
            _categories.Add(category);
        }

        public static List<Category> GetCategories() => _categories;    // return 確認商品現況

        // 根據指定的 CategoryId Read 對應資料(如果找不到對應資料，返回 null)
        public static Category? GetCategoryById(int categoryid)   
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryid);
            if(category != null)    // 避免 Caller 直接操作 Repository 中的實際資料，返回一份複製的的 Category
            {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description,
                };              
            }
            return null;
        }


        // Update
        public static void UpdateCategory(int categoryid, Category category)
        {
            if (categoryid != category.CategoryId) return;

            var categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == categoryid);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

        public static void DeleteCategory(int categoryid)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryid);
            if( category != null )
            {
                _categories.Remove(category);
            }
        }
    }
}
