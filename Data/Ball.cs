

using System.Net.Sockets;

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
        private readonly object locked = new object();
        public event IBall.CoordinatesChangeEventHandler CoordinatesChanged;
        private bool stop = false;


        public Ball(double Y, double X)
        {
            this.XBackingField = X;
            this.YBackingField = Y;
            this.Diamiter = 20;
            this.speedX = Random.NextDouble()*6;
            this.speedY = Random.NextDouble()*6; 
            double vel;

            Thread t = new Thread(() =>
            {
                while (!stop)
                {
                    this.X += this.speedX;
                    this.Y += this.speedY;
                    OnCoordinatesChanged(new CoordinatesChangeEventArgs(X, Y));


                    lock (locked)
                    {
                        vel = Math.Sqrt((SpeedX * SpeedX) + (SpeedY * SpeedY));
                    }

                    Thread.Sleep((int)(100 / vel));

                }

            });
            t.Start();
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
            stop = true;
        }

        private void OnCoordinatesChanged(CoordinatesChangeEventArgs e)
        {
            CoordinatesChanged?.Invoke(this, e);
        }
    }
}

