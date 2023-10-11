using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SaleSeeker_DAL.Classes.DALConstants;

namespace SaleSeeker_DAL.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    [Display(Name = "User")]
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual User? User { get; set; }
    public DateTime CreatedDatetime { get; set; } = DateTime.Now;
    public DateTime UpdatedDatetime { get; set; } = DateTime.Now;

    [Required]
    public string InvoiceNumber { get; set; } = string.Empty;

    [Required]
    public virtual List<Item>? Items { get; set; }

    [Required]
    public string ShippingAddress { get; set; } = string.Empty;

    [Precision(9, 2)]
    public decimal TotalBalance { get; set; }

    public OrderStatus Status { get; set; }

    [Required]
    public PaymentMethod PaymentMethod { get; set; }
}
