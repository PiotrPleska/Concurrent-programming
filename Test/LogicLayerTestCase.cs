using Logic;


namespace Test
{
    [TestClass]
    public class LogicLayerTestCase
    {
        LogicAbstractApi API = LogicAbstractApi.CreateApi();

        [TestMethod]
        public void ApiConstructroTestCase()
        {
            var api = LogicAbstractApi.CreateApi();
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
            List<BallsLogic> lista = API.GetBalls();
            foreach (BallsLogic ball in lista)
            {
                if (ball.X > 400 || ball.X < 0)
                    Assert.Fail();
                if (ball.Y > 420 || ball.Y < 0)
                    Assert.Fail();
            }
        }
    }
}