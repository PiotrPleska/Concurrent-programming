using Concurrent_programming;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Class1 c1 = new Class1();
            Assert.AreEqual(c1.add(1, 2), 3);
        }
    }
}