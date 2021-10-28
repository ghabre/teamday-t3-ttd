using System;

namespace OTPSecurity
{
    public class OTPService
    {
        public OTPService()
        {
        }

        private const int otpLength = 5;

        public bool ValidateToken(string v)
        {
            if (v.Length < otpLength)
            {
                return false;
            }
            return true;
        }
    }
}