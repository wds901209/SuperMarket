public class ShoppingCart
{
    public int CustomerId { get; set; } // 顧客ID
    public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>(); // 購物車內的商品列表

    // 自動計算總金額
    public decimal TotalAmount => Items.Sum(item => item.Price * item.Quantity);
}

// 購物車內的商品物件(最底層)
public class ShoppingCartItem
{
    public int CategoryId { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; } // 商品數量
}
