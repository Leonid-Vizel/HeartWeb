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
        [MaxLength(16)]
        public string Phone { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Region { get; set; }
        public bool IsFromCity { get; set; }
        public bool Admin { get; set; }

        public UserEditModel ToEditModel()
        {
            return new UserEditModel()
            {
                Id = Id,
                Name = Name,
                Phone = Phone,
                Region = Region,
                IsFromCity = Convert.ToInt32(IsFromCity)
            };
        }

        public void Update(User user)
        {
            if (!string.Equals(Name, user.Name))
            {
                Name = user.Name;
            }
            if (!string.Equals(Phone, user.Phone))
            {
                Phone = user.Phone;
            }
            if (!string.Equals(Region, user.Region))
            {
                Region = user.Region;
            }
            if (IsFromCity != user.IsFromCity)
            {
                IsFromCity = user.IsFromCity;
            }
        }
    }
}
