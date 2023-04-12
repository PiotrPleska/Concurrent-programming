namespace Data
{

    internal class Data : DataAbstractApi
    {
        private Ball ball;

        public override IBall getBall()
        {
            return ball;
        }

        public override void Dispose()
        {
            ball?.Dispose();
        }

        public override IBall generateBall()
        {
            Random random = new Random();
            Ball newBall = new Ball(random.Next(100, 400 - 100), random.Next(100, 400 - 100));
            return newBall;
        }

    }




}
