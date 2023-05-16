

using System.Net.Sockets;
using System.Numerics;

namespace Data
{
    internal class Ball : IBall, IDisposable
    {



        private Random Random = new Random();
        //private double YBackingField;
        //private double XBackingField;
        private Vector2D coordinates;
        private Vector2D speed;
        //private double speedX;
        //private double speedY;
        public delegate void CoordinatesChangeEventHandler(object sender, CoordinatesChangeEventArgs e);
        public CoordinatesChangeEventHandler CoordinatesChangeHandler;
        public event IBall.CoordinatesChangeEventHandler CoordinatesChanged;
        private bool stop = false;


        public Ball(double Y, double X)
        {
            //this.XBackingField = X;
            //this.YBackingField = Y;
            
            
            this.Diamiter = 20;

            //this.speedX = Random.NextDouble()*6;
            //this.speedY = Random.NextDouble()*6;
            speed = new Vector2D(Random.NextDouble() * 6, Random.NextDouble() * 6);
            coordinates = new Vector2D(X,Y);
            Thread t = new Thread(() =>
            {
                while (!stop)
                {
                    //this.X += this.speedX;
                    //this.Y += this.speedY;
                    coordinates.AddAssign(speed);
                    OnCoordinatesChanged(new CoordinatesChangeEventArgs(coordinates));
                    Thread.Sleep(1000/60);
                }

            });
            t.Start();
        }
        public Vector2D Speed { get { return speed; } }
        public Vector2D Coordinates { get { return coordinates; } }

        //public double Y
        //{
        //    get { return YBackingField; }
        //    private set
        //    {
        //        if (YBackingField == value)
        //            return;
        //        YBackingField = value;
        //    }
        //}

        public double Diamiter { get;}


        //public double X
        //{
        //    get { return XBackingField; }
        //    private set
        //    {
        //        if (XBackingField == value)
        //            return;
        //        XBackingField = value;
        //    }
        //}

        Vector2D IBall.Speed { get => speed; set => speed = value;
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

