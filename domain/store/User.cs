using Microsoft.AspNetCore.Identity;

namespace domain.store
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
