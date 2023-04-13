using Data;

namespace DataTestSuit
{
    [TestClass]
    public class DataTestCase
    {
        [TestMethod]
        public void CreateAPITest()
        {
            var api = DataAbstractApi.CreateApi();
            Assert.IsNotNull(api);
        }

        readonly DataAbstractApi API = DataAbstractApi.CreateApi();

        [TestMethod]
        public void generateBallTest()
        {
            IBall ball = API.generateBall();
            Assert.IsNotNull(ball);
            Assert.IsNotNull(ball.X);
            Assert.IsNotNull(ball.Y);
            Assert.IsNotNull(ball.Diamiter);
        }

        [TestMethod]
        public void GetBallTest()
        {
            IBall ball = API.generateBall();
            IBall ball2 = API.getBall();
            Assert.AreEqual(ball, ball2);
        }

        [TestMethod]
        public void BallsRandomStartingCoordinatesTest()
        {
            IBall ball1 = API.generateBall();
            IBall ball2 = API.generateBall();
            Assert.AreNotEqual(ball1.X, 0);
            Assert.AreNotEqual(ball1.Y, 0);
            Assert.AreNotEqual(ball2.X, 0);
            Assert.AreNotEqual(ball2.Y, 0);
            Assert.AreNotEqual(ball1.X, ball2.X);
            Assert.AreNotEqual(ball1.Y, ball2.X);
        }
    }
}