using Microsoft.AspNetCore.Identity;

namespace SaleSeeker_DAL.Models;

public class User : IdentityUser
{
    public string Name { get; set; } = string.Empty;
    public string SurName { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    public bool IsActive { get; set; }
}
