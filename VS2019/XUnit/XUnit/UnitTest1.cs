using System;
using Xunit;

namespace XUnit
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True("Zekiri".Length == 5);
        }
    }
}
