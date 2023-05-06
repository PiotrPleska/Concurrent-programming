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


    }
}
