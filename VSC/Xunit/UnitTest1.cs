using System;
using Xunit;

namespace Xunit
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("AAA")]
        [InlineData("BB")]
        [InlineData("CCCCC")]
        public void Test1(string name)
        {
            Assert.True(name.Length == 3);
        }
    }
}
