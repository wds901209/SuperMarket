using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Customer
    {
        public int Id { get; set; }            // 客戶ID
        public required string Name { get; set; }       // 客戶名稱
        public required string Address { get; set; }    // 客戶地址
        public required string Phone { get; set; }      // 客戶電話
        public required string Email { get; set; }      // 客戶信箱
        public string? CustomerName { get; internal set; }
    }
}

