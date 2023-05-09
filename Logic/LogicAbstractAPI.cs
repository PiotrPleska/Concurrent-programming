using Data;

namespace Logic
{
    public interface ILogicBall
    {
        public delegate void CoordinatesChangeEventHandler(object sender, CoordinatesChangeEventArgs e);
        event CoordinatesChangeEventHandler CoordinatesChanged;
        public double X { get;}
        public double Y { get;  }
        public double Diamiter { get; }

        public double speedX { get; }

        public double speedY { get; }
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

    public abstract class LogicAbstractApi : IDisposable
    {
        public static LogicAbstractApi CreateApi(DataAbstractApi? abstractDataApi)
        {
            return new Logic(abstractDataApi);
        }
        public static LogicAbstractApi CreateApi()
        {
            return new Logic();
        }

        public abstract ILogicBall getBall();

        public abstract  List<ILogicBall> GetBalls();

        public abstract void Start(int ballCount);
        public abstract void Dispose();

    }
}