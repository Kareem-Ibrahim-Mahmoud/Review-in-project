using System.ComponentModel.DataAnnotations;

namespace Financial_Stock.DTO
{
    public class RegisterUser
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "The field must be exactly 11 digits.")]
        public string PhoneNumber { get; set; }



    }
}
