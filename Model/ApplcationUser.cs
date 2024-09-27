using Microsoft.AspNetCore.Identity;

namespace Financial_Stock.Model
{
    public class ApplicationUser : IdentityUser
    {


        public ICollection<Orders> Orders { get; set; }
    }
}
