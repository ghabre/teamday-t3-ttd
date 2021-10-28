using Microsoft.VisualStudio.TestTools.UnitTesting;
using OTPSecurity;

namespace OTPSecurityTests
{
    [TestClass]
    public class UnitTest_OTP
    {
        public void TestOTPLength()
        {
            OTPService otpService = new OTPService();
            Assert.AreEqual(true, otpService.ValidateToken("abc"));
        }



        [TestMethod]
        public void BasicRooterTest()
        {
            // Create an instance to test:
            Rooter rooter = new Rooter();
            // Define a test input and output value:
            double expectedResult = 2.0;
            double input = expectedResult * expectedResult;
            // Run the method under test:
            double actualResult = rooter.SquareRoot(input);
            // Verify the result:
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 100);
        }
    }
}
