using System;
using System.Collections.Generic;
using System.Text;

namespace Alat.Dtos
{
    public class VerifyOtpDto
    {
        public string PhoneNumber { get; set; }
        public string  OtpCode { get; set; }
    }
}
