

namespace Data
{
    internal class Ball : IBall, IDisposable
    {
        private Random Random = new Random();
        private double YBackingField;
        private double XBackingField;
        private double speedX;
        private double speedY;
        public delegate void CoordinatesChangeEventHandler(object sender, CoordinatesChangeEventArgs e);
        public CoordinatesChangeEventHandler CoordinatesChangeHandler;
        public event IBall.CoordinatesChangeEventHandler CoordinatesChanged;


        public Ball(double Y, double X)
        {
            XBackingField = X;
            YBackingField = Y;
            Diamiter = 20;
            speedX = Random.NextDouble()*6;
            speedY = Random.NextDouble()*6;
        }
        public double SpeedX { get { return speedX; } }
        public double SpeedY { get { return speedY; } }

        public double Y
        {
            get { return YBackingField; }
            set
            {
                if (YBackingField == value)
                    return;
                YBackingField = value;
                OnCoordinatesChanged(new CoordinatesChangeEventArgs(X, Y));
            }
        }

        public double Diamiter { get;}


        public double X
        {
            get { return XBackingField; }
            set
            {
                if (XBackingField == value)
                    return;
                XBackingField = value;
                OnCoordinatesChanged(new CoordinatesChangeEventArgs(X, Y));
            }
        }

        double IBall.speedX { get => speedX; set => speedX = value;
        }
        double IBall.speedY { get => speedY; set => speedY = value;
        }

        public void Dispose()
        {
            
        }
        public void Move()
        {
            this.X += this.speedX;
            this.Y += this.speedY;
            OnCoordinatesChanged(new CoordinatesChangeEventArgs(X, Y));
        }

        private void OnCoordinatesChanged(CoordinatesChangeEventArgs e)
        {
            CoordinatesChanged?.Invoke(this, e);
        }

    }
}

