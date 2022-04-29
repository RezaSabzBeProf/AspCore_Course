using System.ComponentModel.DataAnnotations;

namespace AspCore_Course.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public UserRole Role { get; set; }
    }
    public enum UserRole
    {
        NormalUser,
        Writer,
        Admin
    }
}
