
namespace Data
{

    internal class Data : DataAbstractApi
    {
        private Ball ball;
        private List<IBall> ballList = new List<IBall>();
        private readonly object locked = new object();
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
            this.ball = newBall;
            Thread t = new Thread(() =>
            {
                while (true)
                {
                    lock (locked)
                    {
                        newBall.Move();
                    }

                    double vel = Math.Sqrt((newBall.SpeedX * newBall.SpeedX) + (newBall.SpeedY * newBall.SpeedY));

                    Thread.Sleep((int)(100 / vel));
                }

            });
            t.Start();
            return newBall;
        }

        public override void Start(int ballCount)
        {
            if (ballList != null) ballList.Clear();
            for (int i = 0; i < ballCount; i++)
            {
                IBall newBall;
                do
                {
                    newBall = generateBall();
                }
                while (CheckCollisions(ballList, newBall));
                ballList.Add(newBall);
            }
        }

        private bool Overlap(IBall b1, IBall b2)
        {
            double xDiff = b1.X - b1.X;
            double yDiff = b1.Y - b1.Y;
            double distance = Math.Sqrt((xDiff * xDiff) + (yDiff * yDiff));
            if (distance <= (b1.Diamiter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckCollisions(List<IBall> balls, IBall b1)
        {
            for (int i = 0; i < balls.Count; i++)
            {
                if (balls[i] != b1) continue;
                if (Overlap(balls[i], b1))
                {
                    return true;
                }
            }
            return false;
        }

        public override List<IBall> getBalls()
        {
            return ballList;
        }
    }




}
