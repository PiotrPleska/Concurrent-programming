using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Logic;
using CoordinatesChangeEventArgs = Logic.CoordinatesChangeEventArgs;

namespace ModelTestSuit
{
    internal class TestLogicBall : ILogicBall
    {
        private double x;
        private double y;
        private double diameter;
        private double SpeedX;
        private double SpeedY;

        public delegate void CoordinatesChangeEventHandler(object sender, CoordinatesChangeEventArgs e);
        private static DataAbstractApi API = DataAbstractApi.CreateApi();
        private IBall Ball = API.getBall();
        private List<IBall> balls = TestLogic.dataLayerr.getBalls();

        public event ILogicBall.CoordinatesChangeEventHandler CoordinatesChanged;

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

        public TestLogicBall(IBall ball)
        {
            this.Ball = ball;
            x = ball.X;
            y = ball.Y;
            diameter = ball.Diamiter;
            ball.CoordinatesChanged += UpdateCoordinates;
        }

        private void UpdateCoordinates(object sender, EventArgs e)
        {
            x = Ball.X;
            y = Ball.Y;
            borderColision(Ball);
            BallCollision(Ball);
            OnCoordinatesChanged(new CoordinatesChangeEventArgs(x, y));
        }

        protected virtual void OnCoordinatesChanged(CoordinatesChangeEventArgs e)
        {
            CoordinatesChanged?.Invoke(this, e);
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
