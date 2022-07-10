using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alat.Model
{
    public class ApplicationUser : IdentityUser
    {
     public string FirstName { get; set; }
     public string LastName { get; set; }
     public int  LgaId { get; set; }
     public  Lga Lga { get; set; }
    }
}
