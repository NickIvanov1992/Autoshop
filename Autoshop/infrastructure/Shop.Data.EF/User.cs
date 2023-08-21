using Microsoft.AspNetCore.Identity;

namespace Shop.Data.EF
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
