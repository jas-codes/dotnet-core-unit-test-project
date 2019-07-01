using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestDemoApplication.Interfaces {
    public interface ITestLogic
    {
        int AddingNumbers(int input1, int input2);
        int AddingNumbersAppSettings(int input1);
    }      
}
