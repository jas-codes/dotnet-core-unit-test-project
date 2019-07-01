using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestDemoApplication.Interfaces;
using UnitTestDemoApplication.Logic;
using UnitTestDemoApplication.Models;
using UTestsForApp.Tests.CustomDataSources;

namespace UTestsForApp.Tests
{
    [TestClass]
    class TestLogicCustomDataSource
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
        [AddingNumbersDataSource]
        public void TestLogic_AddingNumbers_2Inputs(/*Arrange*/int input, int expected, string Testname)
        {
            //act
            int actual = _testLogic.AddingNumbers(input, input);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
