using Microsoft.VisualStudio.TestTools.UnitTesting;
using OTPSecurity;
using OTPSecurity.Model;

namespace OTPSecurityTests
{
    [TestClass]
    public class UnitTest_OTP
    {
        [TestMethod]
        public void TestOTPLength()
        {
            OTPService otpService = new OTPService();
            Assert.AreEqual(true, otpService.ValidateToken("abcde"));
        }

        public void TestValidate()
        {
            OTPService otpService = new OTPService();
            ValidateOTPModel model = new ValidateOTPModel();
            Assert.AreEqual(true, otpService.ValidateToken("abcde"));
        }


    }
}
