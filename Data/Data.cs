using System.Net.Sockets;

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
                Thread t = new Thread(() => {
                    while (true) { 
                        lock (locked)
                        {
                            newBall.Move();
                        }

                        Thread.Sleep(1);
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
                newBall = generateBall();
                ballList.Add(newBall);
            }
        }

        public override List<IBall> getBalls()
        {
            return ballList;
        }
    }




}
