using Data;

namespace Logic
{

    internal class Logic : LogicAbstractApi
    {
        private LogicBall LogicBall;
        private DataAbstractApi dataLayer;

        private List<ILogicBall> Table = new List<ILogicBall>();
        internal Logic(DataAbstractApi dataLayer = null)
        {

            this.dataLayer = DataAbstractApi.CreateApi();

        }


        public override void Dispose()
        {
            dataLayer?.Dispose();
        }

        public override ILogicBall getBall()
        {
            return LogicBall;
        }

        public override  List<ILogicBall> GetBalls()
        {
            if(Table != null) Table.Clear();
            foreach (IBall b in dataLayer.getBalls())
            {
                Table.Add(new LogicBall(b));
            }
            return Table;
        }

        public void BallCollision(IBall ball)
        {
            foreach (IBall b in Table)
            {
                if (b == ball)
                {
                    continue;
                }
                double xDiff = b.X - ball.X;
                double yDiff = b.Y - ball.Y;
                double distance = Math.Sqrt((xDiff * xDiff) + (yDiff * yDiff));
                if (distance <= (ball.Diamiter + b.Diamiter))
                {
                    double newSpeed = b.speedX + (ball.speedX * 2);
                    ball.speedX = ((ball.speedX + b.speedX * 2));
                    b.speedX = newSpeed;

                    newSpeed = b.speedY + (ball.speedY * 2);
                    ball.speedY = ball.speedY + (b.speedY * 2);
                    b.speedY = newSpeed;
                }
            }
        }

        public override void Start(int ballCount)
        {
            dataLayer.Start(ballCount);
        }
    }
}
