using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTestDemoApplication.Interfaces;
using UnitTestDemoApplication.Logic;
using UnitTestDemoApplication.Models;

namespace UTestsForApp
{
    [TestClass]
    public class TestLogicConventional
    {
        private TestLogic _testLogic;
        private Mock<ITestRepository> _testRepoMock = null;
        private Mock<IOptions<AppSettings>> _appSettingsMock = null;

        [TestInitialize]
        public void Setup()
        {
            AppSettings appSettings = new AppSettings() { AddableNumber = 5 };

            _testRepoMock = new Mock<ITestRepository>();
            _testRepoMock.Setup(tr => tr.getValueFromTheDatabase()).Returns(5);

            _appSettingsMock = new Mock<IOptions<AppSettings>>();
            _appSettingsMock.Setup(appSets => appSets.Value).Returns(appSettings);

            _testLogic = new TestLogic(_testRepoMock.Object, _appSettingsMock.Object);

            
        }

        [TestMethod]
        public void PositiveNumbersHandedIn_AddingNumbers_ReturnsEqual()
        {
            //arrange
            int input1 = 5, input2 = 5, expected = 15;
            //act
            int result = _testLogic.AddingNumbers(input1, input2);
            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NegativeNumbersHandedIn_AddingNumbers_ReturnsEqual()
        {
            //arrange
            int input1 = -5, input2 = -5, expected = -5;
            //act
            int result = _testLogic.AddingNumbers(input1, input2);
            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ZerosHandedIn_AddingNumbers_ReturnsEqual()
        {
            //arrange
            int input1 = 0, input2 = 0, expected = 5;
            //act
            int result = _testLogic.AddingNumbers(input1, input2);
            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MockingAppSettings_AddingNumbersAppSettings_ReturnsEqual()
        {
            //arrange
            int input1 = 5, expected = 10;
            //act
            int result = _testLogic.AddingNumbersAppSettings(input1);
            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
