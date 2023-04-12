using Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logic
{
    
    internal class LogicBall : ILogicBall,INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler? PropertyChanged;
        private static DataAbstractApi API = DataAbstractApi.CreateApi();
        private IBall Ball = API.getBall();

        double ILogicBall.X
        {
            get => Ball.X;
            set => Ball.X = value;
        }

        double ILogicBall.Y
        {
            get => Ball.Y;
            set => Ball.Y = value;
        }

        public double Diamiter
        {
            get { return Ball.Diamiter; }
        }

        public LogicBall(IBall ball)
        {
this.Ball = ball;
            // ball.PropertyChanged+= UpdateCoordinates;
        }

        private void UpdateCoordinates(object sender, EventArgs e)
        {
            ((ILogicBall)this).X = Ball.X;
            ((ILogicBall)this).Y = Ball.Y;
            borderColision(Ball);
            RaisePropertyChanged();
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void borderColision(IBall ball)
        {


            if ((Ball.X + Ball.Diamiter) >= 395)
            {

                Ball.X = 395 - Ball.Diamiter;
            }
            if ((Ball.X - Ball.Diamiter) <= 0)
            {
                Ball.X = Ball.Diamiter;
            }
            if ((Ball.Y + Ball.Diamiter) >= 415)
            {
                Ball.Y = 415 - Ball.Diamiter;
            }
            if ((Ball.Y - Ball.Diamiter) <= 0)
            {
                Ball.Y = Ball.Diamiter;
            }

        }


    }
}
