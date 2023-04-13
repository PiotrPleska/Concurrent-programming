using Logic;

namespace LogicTestSuit
{
    [TestClass]
    public class LogiCTestCase
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