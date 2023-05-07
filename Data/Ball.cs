using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data
{
    internal class Ball : IBall, IDisposable, INotifyPropertyChanged
    {
        private Timer MoveTimer;
        private Random Random = new Random();
        private double YBackingField;
        private double XBackingField;
        private double speedX;
        private double speedY;
        public Ball(double Y, double X)
        {
            XBackingField = X;
            YBackingField = Y;
            Diamiter = 20;
            speedX = Random.NextDouble();
            speedY = Random.NextDouble();
        }


        public double Y
        {
            get { return YBackingField; }
            set
            {
                if (YBackingField == value)
                    return;
                YBackingField = value;
                RaisePropertyChanged();
            }
        }

        public double Diamiter { get; set; }


        public double X
        {
            get { return XBackingField; }
            set
            {
                if (XBackingField == value)
                    return;
                XBackingField = value;
                RaisePropertyChanged();
            }
        }

        double IBall.speedX { get => speedX; set => speedX = value;
        }
        double IBall.speedY { get => speedY; set => speedY = value;
        }

        public void Dispose()
        {
            MoveTimer?.Dispose();
        }
        public void Move()
        {
            this.X += this.speedX;
            this.Y += this.speedY;
            RaisePropertyChanged();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

