using System.ComponentModel.DataAnnotations;

namespace AspCore_Course.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? ShortDesc { get; set; }

        public string? Body { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        public User? User { get; set; }

    }
}
