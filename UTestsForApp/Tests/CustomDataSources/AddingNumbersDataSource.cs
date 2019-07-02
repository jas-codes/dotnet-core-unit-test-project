using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace UTestsForApp.Tests.CustomDataSources
{
    class AddingNumbersDataSource : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { 5, 15, "PositiveNumbersHandedIn_AddingNumbers_ReturnsEqual" };
            yield return new object[] { 0, 5, "ZeroesHandedIn_AddingNumbers_ReturnsEqual" };
            yield return new object[] { -5, -5, "NegativeNumbersHandedIn_AddingNumbers_ReturnsEqual" };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Test - {0}", data[2]);
            return null;
        }
    }
}
