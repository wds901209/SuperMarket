using System.Collections.Generic;

namespace WebApp.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; } // 購物車 ID
        public int CustomerId { get; set; } // 關聯客戶 ID
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>(); // 購物車內商品列表

        public decimal TotalAmount => CalculateTotal(); // 自動計算總金額

        private decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.ProductPrice * item.Quantity;
            }
            return total;
        }
    }
}
