using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alat.Dtos
{
    public class VerificationDto
    {
        [Required]
        public string PhoneNumber { get; set; }
    }
}
