using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MStest
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow(5)]
        [DataRow(10)]
        [DataRow(15)]
        [DataRow(20)]
        public void TestMethod1(int valnb)
        {
            Assert.IsTrue(valnb == 5);
        }
    }
}
