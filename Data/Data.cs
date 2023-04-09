using System.Reactive;
using System.Reactive.Linq;

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


        public override void Start()
        {
            if (Balls2Dispose != null)
            {
                Balls2Dispose.Clear();
            }
            Random random = new Random();
            int ballNumber = random.Next(1, 10);
            for (int i = 0; i < ballNumber; i++)
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
