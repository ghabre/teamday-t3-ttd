using OTPSecurity.Model;
using System;

namespace OTPSecurity
{
    public class OTPService
    {
        public OTPService()
        {
        }

        private const int otpLength = 5;

        public bool ValidateToken(ValidateOTPModel model)
        {
            if (model.OTP.Length < otpLength)
            {
                return false;
            }
            return true;
        }
    }
}