using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace SaleSeeker_DAL.Models;

public class Role : IdentityRole
{
    [DefaultValue(true)]
    public bool IsActive { get; set; }
}
