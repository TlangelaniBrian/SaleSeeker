using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SaleSeeker_DAL.Classes.DALConstants;

namespace SaleSeeker_DAL.Models;

public class Wallet
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedDatetime { get; set; } = DateTime.Now;
    [Display(Name = "User")]
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual User? User { get; set; }
    public PaymentMethod PreferredPaymentMethod { get; set; }
    public decimal AvailableCredit { get; set; }
}