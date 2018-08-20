using System.ComponentModel.DataAnnotations;

namespace Invent.Web.Common.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [Required]
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public int CompanyId { get; set; }
    }
}
