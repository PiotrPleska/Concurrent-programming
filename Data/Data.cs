namespace Data
{

    internal class Data : DataAbstractApi
    {
        private Ball ball;
        private List<Ball> Balls2Dispose = new List<Ball>();
        public override void Dispose()
        {
            ball.Dispose();
        }

        public override Ball GenerateBall()
        {
            Random random = new Random();
            Ball newBall = new Ball(random.Next(100, 400 - 100), random.Next(100, 400 - 100));
            return newBall;
        }


        public override void Start(int ballCount)
        {
            if (Balls2Dispose != null)
            {
                Balls2Dispose.Clear();
            }
            for (int i = 0; i < ballCount; i++)
            {
                Ball newBall = GenerateBall();
                Balls2Dispose.Add(newBall);
            }
        }

        public override List<Ball> GetAll()
        {
            return Balls2Dispose;
        }

    }




}
