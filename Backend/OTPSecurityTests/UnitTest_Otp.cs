using Microsoft.VisualStudio.TestTools.UnitTesting;
using OTPSecurity;
using OTPSecurity.Model;

namespace OTPSecurityTests
{
    [TestClass]
    public class UnitTest_OTP
    {
        [TestMethod]
        public void OTPLengthTest()
        {
            OTPService otpService = new OTPService();
            var expectedOutput = true;
            ValidateOTPModel model = new ValidateOTPModel();
            Assert.AreEqual(expectedOutput, otpService.ValidateToken(model));
        }

        [TestMethod]
        public void EmailValidateTest()
        {
            OTPService otpService = new OTPService();
            var expectedOutput = true;
            ValidateOTPModel model = new ValidateOTPModel();
            Assert.AreEqual(expectedOutput, otpService.ValidateToken(model));
        }

        [TestMethod]
        public void TimeDurationValidateTest()
        {
            OTPService otpService = new OTPService();
            var expectedOutput = true;
            ValidateOTPModel model = new ValidateOTPModel();
            Assert.AreEqual(expectedOutput, otpService.ValidateToken(model));
        }






    }
}
