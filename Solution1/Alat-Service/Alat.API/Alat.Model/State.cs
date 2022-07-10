using System;
using System.Collections.Generic;
using System.Text;

namespace Alat.Model
{
     public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public ICollection<Lga> lgas { get; set; }
    }
}
