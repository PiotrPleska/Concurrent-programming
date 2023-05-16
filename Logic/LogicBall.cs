using Data;

namespace Logic
{

    internal class LogicBall : ILogicBall

    {
        Vector2D coordinates;
        private double diameter = 20;


        private readonly object locked = new object();


        public delegate void CoordinatesChangeEventHandler(object sender, CoordinatesChangeEventArgs e);
        private static DataAbstractApi API = DataAbstractApi.CreateApi();
        //private IBall Ball = API.getBall();
        private List<IBall> balls = Logic.dataLayerr.getBalls();

        public event ILogicBall.CoordinatesChangeEventHandler CoordinatesChanged;


        public double Diamiter => diameter;

        public Vector2D Coordinates => coordinates;

        //double ILogicBall.speedX => SpeedX;

        //double ILogicBall.speedY => SpeedY;

        public LogicBall(IBall ball)
        {
            //this.Ball = ball;
            //x = ball.X;
            //y = ball.Y;
            //diameter = ball.Diamiter;
            ball.CoordinatesChanged += UpdateCoordinates;
        }

        private void UpdateCoordinates(object sender, EventArgs e)
        {
            //x = Ball.X;
            //y = Ball.Y;

            IBall Ball = (IBall)sender;
            coordinates = Ball.Coordinates;

            borderColision(Ball);
            lock (locked){
                BallCollision(Ball);
            }


            OnCoordinatesChanged(new CoordinatesChangeEventArgs(coordinates));
        }

        protected virtual void OnCoordinatesChanged(CoordinatesChangeEventArgs e)
        {
            CoordinatesChanged?.Invoke(this, e);
        }

        private void borderColision(IBall ball)
        {


            //if ((x + diameter) >= 395)
            //{
            //    ball.speedX = -ball.speedX;
            //    x = 395 - diameter;
            //}
            //if ((y + diameter) >= 415)
            //{
            //    ball.speedY = -ball.speedY;
            //    y = 415 - diameter;
            //}

            if(coordinates.Add(diameter, diameter) >= new Vector2D(395, 415))
            {
                ball.Speed = -ball.Speed;
                coordinates = new Vector2D(395 - diameter, 415 - diameter);
            }

            //if ((x - diameter) <= -20)
            //{
            //    ball.speedX = -ball.speedX;
            //    x = diameter;
            //}
            //if ((y - diameter) <= -20)
            //{
            //    ball.speedY = -ball.speedY;
            //    y = diameter;
            //}
            if (coordinates.SubractScalar(diameter, diameter) <= new Vector2D(-20, -20))
            {
                ball.Speed = -ball.Speed;
                coordinates = new Vector2D(diameter,diameter);
            }


        }

        public void BallCollision(IBall ball)
        {
            foreach (IBall b in balls)
            {
                if (b == ball)
                {
                    continue;
                }
                Vector2D Diff = b.Coordinates.Subtract(ball.Coordinates);
                double distance = Math.Sqrt(Diff.Multiply());
                if (distance <= (ball.Diamiter))
                {
                    if (Vector2D.CheckCollision(ball.Coordinates,b.Coordinates))
                    {
                        //double newSpeed = ball.speedX;
                        //ball.speedX = b.speedX;
                        //b.speedX = newSpeed;

                        //newSpeed = ball.speedY;
                        //ball.speedY = b.speedY;
                        //b.speedY = newSpeed;

                        Vector2D temp = ball.Speed;
                        ball.Speed = b.Speed;
                        b.Speed = temp;
                    }

                }
            }
        }



    }
}
