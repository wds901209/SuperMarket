namespace WebApp.Models
{
    public class InvoiceItem
    {
        public int ProductId { get; set; } // 商品 ID
        public string ProductName { get; set; } // 商品名稱
        public decimal ProductPrice { get; set; } // 商品單價
        public int Quantity { get; set; } // 購買數量
    }
}
