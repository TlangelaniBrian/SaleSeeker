using System.ComponentModel.DataAnnotations;

namespace SaleSeeker_DAL.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}
