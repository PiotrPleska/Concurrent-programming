using Data;
using Logic;
using Model;

namespace Test
{
    [TestClass]
    public class GeneralTestCase
    {
        [TestMethod]
        public void BallConstructorTest()
        {
            Ball ball = new Ball(0, 0);
            Assert.IsNotNull(ball);
        }

        Ball ball = new Ball(0, 0);
        [TestMethod]
        public void BallIsNotNullTestCase()
        {
            Assert.IsNotNull(ball);
        }

        [TestMethod]
        public void generateBallTest()
        {
            var API = DataAbstractApi.CreateApi();
            Ball ball = API.GenerateBall();
            Assert.IsNotNull(ball);
            Assert.IsNotNull(ball.X);
            Assert.IsNotNull(ball.Y);
            Assert.IsNotNull(ball.diameter);

        }
        // [TestMethod]
        // public void BallGetterTest()
        // {
        //     Assert.AreEqual(0, ball.X);
        //     Assert.AreEqual(0, ball.Y);
        //     Assert.AreEqual(20, ball.diameter);
        // }
        //
        // [TestMethod]
        // public void BallSetterTest()
        // {
        //     Ball ball = new Ball(0, 0);
        //     ball.X = 10;
        //     ball.Y = 15;
        //
        //     Assert.AreEqual(10, ball.X);
        //     Assert.AreEqual(15, ball.Y);
        // }


        [TestMethod]
        public void DataTraversalTest()
        {
            BallsLogic logicBall = new BallsLogic(ball);
            ModelBall modelBall = new ModelBall(logicBall);

            Assert.AreEqual(ball.X, logicBall.X);
            Assert.AreEqual(logicBall.X, modelBall.X);

            Assert.AreEqual(ball.Y, logicBall.Y);
            Assert.AreEqual(logicBall.Y, modelBall.Y);

            Assert.AreEqual(ball.diameter, logicBall.Diameter);
            Assert.AreEqual(logicBall.Diameter, modelBall.Diameter);
        }
    }
}