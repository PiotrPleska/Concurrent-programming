

namespace Data
{

    public interface IBall
    {
        public delegate void CoordinatesChangeEventHandler(object sender, CoordinatesChangeEventArgs e);
        event CoordinatesChangeEventHandler CoordinatesChanged;
        double X { get;}
        double Y { get; }
        double Diamiter { get; }
        double speedX { get; set; }
        double speedY { get; set; }
    }

    public class CoordinatesChangeEventArgs : EventArgs
    {

        public CoordinatesChangeEventArgs(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; internal set; } 
        public double Y { get; internal set; }



    }

    public abstract class DataAbstractApi :IDisposable
    {

        public static DataAbstractApi CreateApi()
        {
            Data data = new Data();
            return data;
        }

        public abstract IBall getBall();
        public abstract IBall generateBall();

        public abstract List<IBall> getBalls();

        public abstract void Dispose();

        public abstract void Start(int ballCount);

    }




}
