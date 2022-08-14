using System.ComponentModel.DataAnnotations;

namespace HeartWeb.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
    }
}
