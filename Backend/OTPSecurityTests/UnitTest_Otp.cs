using Microsoft.VisualStudio.TestTools.UnitTesting;
using OTPSecurity;
using OTPSecurity.Model;
using System;
using System.Threading.Tasks;

namespace OTPSecurityTests
{
    [TestClass]
    public class UnitTest_OTP
    {

        [TestMethod]
        public void GenerateOtpTest()
        {
            // Arrange
            var otpService = new OTPService();

            // Act
            var otp = otpService.GenerateOtp("user@email.com", "12345");

            // Assert
            Assert.IsTrue(!string.IsNullOrEmpty(otp));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateOtpTestInvalidInputs()
        {
            // Arrange
            var otpService = new OTPService();

            // Act
            var otp = otpService.GenerateOtp(null, "12345");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateOtpTestInvalidEmail()
        {
            // Arrange
            var otpService = new OTPService();

            // Act
            var otp = otpService.GenerateOtp("bla", "12345");
        }




        [TestMethod]
        public void ValidateOtpWithCorrectCode()
        {
            // Arrange
            var otpService = new OTPService();

            var email = "user@email.com";

            var otp = otpService.GenerateOtp(email, "12345");

            var model = new ValidateOTPModel
            {
                Email = email,
                OTP = otp
            };

            // Act
            var validate = otpService.ValidateOtp(model);


            // Assert
            Assert.IsTrue(validate);
        }



        [TestMethod]
        public void ValidateOtpWithInCorrectCode()
        {
            // Arrange
            var otpService = new OTPService();

            var email = "user@email.com";

            var otp = otpService.GenerateOtp(email, "12345");

            var model = new ValidateOTPModel
            {
                Email = email,
                OTP = otp + "1"
            };

            // Act
            var validate = otpService.ValidateOtp(model);


            // Assert
            Assert.IsFalse(validate);
        }



        [TestMethod]
        public void EmailValidateTest()
        {
            var otpService = new OTPService();
            var expectedOutput = true;
            var model = new ValidateOTPModel();
            Assert.AreEqual(expectedOutput, otpService.ValidateOtp(model));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TimeDurationValidateTest()
        {
            // Arrange
            var otpService = new OTPService();

            var email = "user@email.com";

            var otp = otpService.GenerateOtp(email, "12345");

            var model = new ValidateOTPModel
            {
                Email = email,
                OTP = otp
            };

            // Act
            var validate = otpService.ValidateOtp(model);


            // Assert
            otp = otpService.GenerateOtp(email, "12345");

        }


        [TestMethod]
        public async Task TimeDurationWaitValidateTest()
        {
            // Arrange
            var otpService = new OTPService(TimeSpan.FromSeconds(1));

            var email = "user@email.com";

            var otp = otpService.GenerateOtp(email, "12345");

            var model = new ValidateOTPModel
            {
                Email = email,
                OTP = otp
            };

            // Act
            var validate = otpService.ValidateOtp(model);

            await Task.Delay(1000);

            otp = otpService.GenerateOtp(email, "12345");

            // Assert
            Assert.IsTrue(!string.IsNullOrEmpty(otp));
        }




    }
}
