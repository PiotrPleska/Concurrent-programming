using Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logic
{
    
    internal class LogicBall : ILogicBall,INotifyPropertyChanged

    {
        private double x;
        private double y;
        private double diameter;
        private double SpeedX;
        private double SpeedY;

        public event PropertyChangedEventHandler? PropertyChanged;
        private static DataAbstractApi API = DataAbstractApi.CreateApi();
        private IBall Ball = API.getBall();
        private List<IBall> balls = Logic.dataLayerr.getBalls();
        double ILogicBall.X
        {
            get => x;
        }

        double ILogicBall.Y
        {
            get => y;
        }

        public double Diamiter => diameter;

        double ILogicBall.speedX => SpeedX;

        double ILogicBall.speedY => SpeedY;

        public LogicBall(IBall ball)
        {
            this.Ball = ball;
            x = ball.X;
            y = ball.Y;
            diameter = ball.Diamiter;
            ball.PropertyChanged += UpdateCoordinates;
        }

        private void UpdateCoordinates(object sender, EventArgs e)
        {
            x = Ball.X;
            y = Ball.Y;
            borderColision(Ball);
            BallCollision(Ball);
            RaisePropertyChanged();
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void borderColision(IBall ball)
        {


            if ((x + diameter) >= 395)
            {
                ball.speedX = -ball.speedX;
                x = 395 - diameter;
            }
            if ((x - diameter) <= -20)
            {
                ball.speedX = -ball.speedX;
                x = diameter;
            }
            if ((y + diameter) >= 415)
            {
                ball.speedY = -ball.speedY;
                y = 415 - diameter;
            }
            if ((y - diameter) <= -20)
            {
                ball.speedY = -ball.speedY;
                y = diameter;
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
                double xDiff = b.X - ball.X;
                double yDiff = b.Y - ball.Y;
                double distance = Math.Sqrt((xDiff * xDiff) + (yDiff * yDiff));
                if (distance <= (ball.Diamiter))
                {
                    double newSpeed = ball.speedX;
                    ball.speedX = b.speedX;
                    b.speedX = newSpeed;

                    newSpeed = ball.speedY;
                    ball.speedY = b.speedY;
                    b.speedY = newSpeed;
                }
            }
        }


    }
}
