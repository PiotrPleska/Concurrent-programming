using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;
using Logic;
using CoordinatesChangeEventArgs = Data.CoordinatesChangeEventArgs;

namespace LogicTestSuit
{
    internal class TestBall : IBall, IDisposable
    {
        private Random Random = new Random();
        private double YBackingField;
        private double XBackingField;
        private double speedX;
        private double speedY;
        public delegate void CoordinatesChangeEventHandler(object sender, CoordinatesChangeEventArgs e);
        public CoordinatesChangeEventHandler CoordinatesChangeHandler;
        public event IBall.CoordinatesChangeEventHandler CoordinatesChanged;


        public TestBall(double Y, double X)
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
                OnCoordinatesChanged(new CoordinatesChangeEventArgs(X, Y));
            }
        }

        public double Diamiter { get; }


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

        double IBall.speedX
        {
            get => speedX; set => speedX = value;
        }
        double IBall.speedY
        {
            get => speedY; set => speedY = value;
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
