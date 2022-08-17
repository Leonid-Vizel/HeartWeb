using System.ComponentModel.DataAnnotations;

namespace HeartWeb.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string Surname { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(16)]
        public string Phone { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Region { get; set; }
        public bool IsFromCity { get; set; }
        public bool Admin { get; set; }
    }
}
