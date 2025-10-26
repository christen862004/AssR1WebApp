using Microsoft.AspNetCore.Identity;

namespace AssR1WebApp.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }//user column
                                            //

    }
}
