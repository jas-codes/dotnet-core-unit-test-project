using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTestDemoApplication.Interfaces;
using UnitTestDemoApplication.Models;

namespace UnitTestDemoApplication.Logic
{
    public class TestLogic : ITestLogic
    {
        private ITestRepository _testRepo;
        private AppSettings _appSettings;

        public TestLogic(ITestRepository testRepository, IOptions<AppSettings> appSettings)
        {
            _testRepo = testRepository;
            _appSettings = appSettings.Value;
        }

        public int AddingNumbers(int input1, int input2)
        {
            return input1 + input2 + _testRepo.getValueFromTheDatabase();
        }

        public int AddingNumbersAppSettings(int input1)
        {
            return input1 + _appSettings.AddableNumber;
        }
    }
}
