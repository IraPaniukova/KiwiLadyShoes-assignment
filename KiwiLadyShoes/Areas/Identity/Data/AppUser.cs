using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KiwiLadyShoes.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{  // added Ira, Victor, 13/10/23
    public String? FirstName { get; set; }
    public String? LastName { get; set; }
    public DateTime Birthday { get; set; }

}

