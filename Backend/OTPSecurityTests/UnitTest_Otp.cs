using Microsoft.VisualStudio.TestTools.UnitTesting;
using OTPSecurity;

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


    }
}
