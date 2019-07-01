using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTestDemoApplication.Interfaces;

namespace UnitTestDemoApplication.Repositories
{
    public class TestRepository : ITestRepository
    {
        public int getValueFromTheDatabase()
        {
            return 50;
        }
    }
}
