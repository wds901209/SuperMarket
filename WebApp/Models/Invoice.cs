public class Invoice
{
    public int CustomerId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
    public decimal TotalAmount { get; set; }

    // 可以加入其他發票需要的欄位，例如發票號碼等
    public required string InvoiceNumber { get; set; }
}
