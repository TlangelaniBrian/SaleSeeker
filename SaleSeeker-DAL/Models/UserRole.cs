namespace SaleSeeker_DAL.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }
}
