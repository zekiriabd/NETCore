using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyMstest
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow(5)]
        [DataRow(10)]
        [DataRow(15)]
        [DataRow(20)]
        public void TestMethod1(int mynb)
        {
            Assert.IsTrue(mynb * 2 == 20);
        }
    }
}
