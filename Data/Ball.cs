

using System.Net.Sockets;

namespace Data
{

    internal class Ball : IBall
    {
        private Random Random = new Random();
        private double YBackingField;
        private double XBackingField;
        private double speedX;
        private double speedY;
        public delegate void CoordinatesChangeEventHandler(object sender, CoordinatesChangeEventArgs e);
        public CoordinatesChangeEventHandler CoordinatesChangeHandler;
        public event IBall.CoordinatesChangeEventHandler CoordinatesChanged;
        private bool stop = false;


        public Ball(double Y, double X)
        {
            this.XBackingField = X;
            this.YBackingField = Y;
            this.Diamiter = 20;
            this.speedX = Random.NextDouble()*6;
            this.speedY = Random.NextDouble()*6; 
           
            Thread t = new Thread(() =>
            {
                while (!stop)
                {
                    this.X += this.speedX;
                    this.Y += this.speedY;
                    OnCoordinatesChanged(new CoordinatesChangeEventArgs(X, Y));



                    Thread.Sleep(10);

                }
                
            });
            t.Start();
        }

        public double Y
        {
            get { return YBackingField; }
            private set
            {
                if (YBackingField == value)
                    return;
                YBackingField = value;
            }
        }

        public double Diamiter { get;}


        public double X
        {
            get { return XBackingField; }
            private set
            {
                if (XBackingField == value)
                    return;
                XBackingField = value;
            }
        }

        double IBall.speedX { get => speedX; set => speedX = value;
        }
        double IBall.speedY { get => speedY; set => speedY = value;
        }

        private void OnCoordinatesChanged(CoordinatesChangeEventArgs e)
        {
            CoordinatesChanged?.Invoke(this, e);
        }

        public void Dispose()
        {
            stop = true;
        }
    }
}

