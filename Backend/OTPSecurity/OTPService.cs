using OTPSecurity.Model;
using System;

namespace OTPSecurity
{
    public class OTPService
    {
        private string temp = null;
        private DateTime last = DateTime.MinValue;
        private readonly TimeSpan _delayBetweenGenerate;

        public OTPService(TimeSpan delayBetweenGenerate = default)
        {
            _delayBetweenGenerate = delayBetweenGenerate == default ? TimeSpan.FromMinutes(5) : delayBetweenGenerate;
        }


        public bool ValidateOtp(ValidateOTPModel model)
        {
            return model.OTP == temp;
        }

        public string GenerateOtp(string email, string application)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException($"'{nameof(email)}' cannot be null or whitespace.", nameof(email));
            }

            if (string.IsNullOrWhiteSpace(application))
            {
                throw new ArgumentException($"'{nameof(application)}' cannot be null or whitespace.", nameof(application));
            }

            if (!email.Contains("@"))
            {
                throw new ArgumentException($"Invalid '{nameof(email)}'");
            }

            if (DateTime.Now.Subtract(_delayBetweenGenerate) < last)
            {
                throw new InvalidOperationException("Not enough time has passed");
            }
            else
            {
                var rand = new Random();

                temp = rand.Next(1000, 9999).ToString();
                last = DateTime.Now;

                return temp;
            }
        }
    }
}