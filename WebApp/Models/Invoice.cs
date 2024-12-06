using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class Invoice
    {
        public int Id { get; set; } // 發票 ID
        public string InvoiceNumber { get; set; } // 發票號碼
        public DateTime IssueDate { get; set; } // 開立日期
        public DateTime? PaymentDate { get; set; } // 收款日期
        public int CustomerId { get; set; } // 關聯客戶 ID
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>(); // 發票內商品明細

        public decimal TotalAmount => CalculateTotal(); // 總金額 (自動計算)

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
