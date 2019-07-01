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
    public class TestLogicDynamicData
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
        [DynamicData(nameof(GetAddingNumbersData), DynamicDataSourceType.Method)]
        public void TestLogic_AddingNumbers_2InputsMethodSyntax(/*Arrange*/int input, int expected, string testName)
        {
            //act
            int actual = _testLogic.AddingNumbers(input, input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        //Method Syntax
        public static IEnumerable<object[]> GetAddingNumbersData()
        {
            yield return new object[] {5,15, "PositiveNumbersHandedIn_AddingNumbers_ReturnsEqual" };
            yield return new object[] { 0, 5, "ZeroesHandedIn_AddingNumbers_ReturnsEqual" };
            yield return new object[] { -5, -5, "NegativeNumbersHandedIn_AddingNumbers_ReturnsEqual" };
        }

        //Property Syntax
        public static IEnumerable<object[]> AddingNumbersData 
        {
            get 
            {
                yield return new object[] { 5, 15, "PositiveNumbersHandedIn_AddingNumbers_ReturnsEqual" };
                yield return new object[] { 0, 5, "ZeroesHandedIn_AddingNumbers_ReturnsEqual" };
                yield return new object[] { -5, -5, "NegativeNumbersHandedIn_AddingNumbers_ReturnsEqual" };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(AddingNumbersData), DynamicDataSourceType.Property)]
        public void TestLogic_AddingNumbers_2InputsPropertySyntax(/*Arrange*/int input, int expected, string testName)
        {
            //act
            int actual = _testLogic.AddingNumbers(input, input);
            //assert
            Assert.AreEqual(expected, actual);
        }

    }
}
