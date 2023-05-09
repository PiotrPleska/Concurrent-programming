using Data;
using Logic;

namespace LogicTestSuit
{
    [TestClass]
    public class LogiCTestCase
    {
        private static TestData data = new TestData();
        // private static DataAbstractApi api = DataAbstractApi.CreateApi();
        LogicAbstractApi API = LogicAbstractApi.CreateApi(data);

        [TestMethod]
        public void ApiConstructroTestCase()
        {
            var api = LogicAbstractApi.CreateApi(data);
            Assert.IsNotNull(api);
        }

        [TestMethod]
        public void LogicStartTest()
        {
            API.Start(1);
            Assert.AreEqual(1, API.GetBalls().Count());
        }

        [TestMethod]
        public void BorderColisionTest()
        {
            API.Start(2);
            List<ILogicBall> lista = API.GetBalls();
            foreach (ILogicBall ball in lista)
            {
                if (ball.X > 400 || ball.X < 0)
                    Assert.Fail();
                if (ball.Y > 420 || ball.Y < 0)
                    Assert.Fail();
            }

        }

        [TestMethod]
        public void GetBallsTest()
        {
            List<ILogicBall> balls = API.GetBalls();
            Assert.IsNotNull(balls);
            foreach (ILogicBall ball in balls)
            {
                Assert.IsNotNull(ball);
            }
        }
    }
}