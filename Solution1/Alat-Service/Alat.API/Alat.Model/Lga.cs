using System;
using System.Collections.Generic;
using System.Text;

namespace Alat.Model
{
     public class Lga
    {
        public int Id { get; set; }
        public string LgaName { get; set; }
        public int StateId { get; set; }
        public State state { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
