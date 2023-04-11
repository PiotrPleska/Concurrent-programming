using Logic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class ModelBall : INotifyPropertyChanged
    {
        private double x;
        private double y;

        public ModelBall(BallsLogic ball)
        {
            this.x = ball.X;
            this.y = ball.Y;
            this.Diameter = ball.Diameter;
            ball.PropertyChanged += UpdateCoordinates;
        }


        public double Y
        {
            get { return y; }
            private set
            {
                if (y == value)
                    return;
                RaisePropertyChanged("Y");
            }
        }

        public double X
        {
            get => x;
            private set
            {
                if (x == value)
                    return;
                RaisePropertyChanged("X");
            }
        }

        public double Diameter { get; }


        private void UpdateCoordinates(object sender, EventArgs e)
        {
            BallsLogic ballsLogic = (BallsLogic)sender;
            x = ballsLogic.X;
            y = ballsLogic.Y;
            RaisePropertyChanged("X");
            RaisePropertyChanged("Y");
        }


        public event PropertyChangedEventHandler? PropertyChanged;


        protected void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}