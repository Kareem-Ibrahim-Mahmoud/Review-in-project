using System.ComponentModel.DataAnnotations;

namespace Financial_Stock.DTO
{
    public class LoginUser
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
