using System;
using System.Collections.Generic;
using System.Text;

namespace Alat.Model
{
    public class OtpVerification
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime ExpiresIn { get; set; }
        public bool IsVerified { get; set; }
        public string Email { get; set; }
        public string PhoneNumber{ get; set; }
    }
}
