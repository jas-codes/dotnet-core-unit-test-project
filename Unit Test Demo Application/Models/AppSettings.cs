using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTestDemoApplication.Interfaces;

namespace UnitTestDemoApplication.Models
{
    public class AppSettings : IAppSettings
    {
        public int AddableNumber { get; set; }
    }
}
