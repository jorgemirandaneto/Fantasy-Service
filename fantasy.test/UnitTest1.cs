using System;
using Xunit;

namespace fantasy.test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var x = "a";
            var y = "a";
            Assert.True(x == y);
        }
    }
}
