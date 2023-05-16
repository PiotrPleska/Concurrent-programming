

namespace Data
{

    public interface IBall
    {
        public delegate void CoordinatesChangeEventHandler(object sender, CoordinatesChangeEventArgs e);
        event CoordinatesChangeEventHandler CoordinatesChanged;
        Vector2D Coordinates { get;}
        double Diamiter { get; }
        Vector2D Speed { get; set; }
        public void Dispose();
    }

    public class CoordinatesChangeEventArgs : EventArgs
    {

        public CoordinatesChangeEventArgs(Vector2D vector2D)
        {
            Vector2D = vector2D;
        }

        public Vector2D Vector2D { get; internal set; } 



    }

    public abstract class DataAbstractApi :IDisposable
    {

        public static DataAbstractApi CreateApi()
        {
            Data data = new Data();
            return data;
        }

        public abstract IBall generateBall();

        public abstract List<IBall> getBalls();

        public abstract void Dispose();

        public abstract void Start(int ballCount);
        

    }




}
