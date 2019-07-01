using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestDemoApplication.Interfaces;
using UnitTestDemoApplication.Logic;
using UnitTestDemoApplication.Models;

namespace UTestsForApp.Tests
{
    [TestClass]
    public class TestLogicDataRow
    {
        private Mock<ITestRepository> _testRepoMock = null;
        private Mock<IOptions<AppSettings>> _appSettingsMock = null;
        private ITestLogic _testLogic;

        [TestInitialize]
        public void Setup()
        {
            _testRepoMock = new Mock<ITestRepository>();
            _appSettingsMock = new Mock<IOptions<AppSettings>>();
            _testLogic = new TestLogic(_testRepoMock.Object, _appSettingsMock.Object);

            _testRepoMock.Setup(tr => tr.getValueFromTheDatabase()).Returns(5);
        }

        [DataTestMethod]
        [DataRow(5, 15,DisplayName = "PositiveNumbersHandedIn_AddingNumbers_ReturnsEqual")]
        [DataRow(0, 5, DisplayName = "ZeroesHandedIn_AddingNumbers_ReturnsEqual")]
        [DataRow(-5, -5, DisplayName = "NegativeNumbersHandedIn_AddingNumbers_ReturnsEqual")]
        public void TestLogic_AddingNumbers_DataRows2Inputs(/*arrange*/ int input, int expected)
        {
            //act
            int result = _testLogic.AddingNumbers(input, input);
            //assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(5, 5, 15, DisplayName = "PositiveNumbersHandedIn_AddingNumbers_ReturnsEqual")]
        [DataRow(0, 0, 5, DisplayName = "ZeroesHandedIn_AddingNumbers_ReturnsEqual")]
        [DataRow(-5, -5, -5, DisplayName = "NegativeNumbersHandedIn_AddingNumbers_ReturnsEqual")]
        public void TestLogic_AddingNumbers_DataRows3Inputs(/*arrange*/ int input1, int input2, int expected)
        {
            //act
            int result = _testLogic.AddingNumbers(input1, input2);
            //assert
            Assert.AreEqual(expected, result);
        }

        


    }
}
