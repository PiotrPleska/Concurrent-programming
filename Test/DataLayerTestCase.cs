using Data;

namespace Test
{
    [TestClass]
    public class DataLayerTestCase
    {
        [TestMethod]
        public void CreateAPITest()
        {
            var api = DataAbstractApi.CreateApi();
            Assert.IsNotNull(api);
        }

        readonly DataAbstractApi API = DataAbstractApi.CreateApi();

        [TestMethod]
        public void StartTestCase()
        {
            Random random = new Random();
            API.Start(random.Next(0, 10));
            List<Ball> balls = API.GetAll();
            foreach (Ball ball in balls)
            {
                Assert.IsNotNull(ball);
                Assert.IsNotNull(ball.X);
                Assert.IsNotNull(ball.Y);
                Assert.IsNotNull(ball.diameter);
                Assert.AreEqual(ball.diameter, 20);
            }
        }
        //
        // [TestMethod]
        // public void BallsRandomStartingCoordinatesTest()
        // {
        //     API.Start(2);
        //     List<Ball> balls = API.GetAll();
        //     Assert.AreNotEqual(balls[0].X, 0);
        //     Assert.AreNotEqual(balls[0].Y, 0);
        //     Assert.AreNotEqual(balls[1].X, 0);
        //     Assert.AreNotEqual(balls[1].X, 0);
        //     Assert.AreNotEqual(balls[0].X, balls[1].X);
        //     Assert.AreNotEqual(balls[0].Y, balls[1].X);
        // }

        [TestMethod]
        public void MovementTest()
        {
            int a = 0;
            Ball ball = new Ball(0, 0);
            for (int i = 0; i < 100_000_000; i++)
            {
                a += i;
            }

            Console.WriteLine(ball.X);
            Console.WriteLine(ball.Y);
            Assert.AreNotEqual(ball.X, 0);
            Assert.AreNotEqual(ball.Y, 0);
        }
    }
}