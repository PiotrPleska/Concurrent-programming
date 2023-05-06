using System.ComponentModel;

namespace Data
{

    public interface IBall : INotifyPropertyChanged
    {
        double X { get;}
        double Y { get; }
        double Diamiter { get; }
        double speedX { get; set; }
        double speedY { get; set; }
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

        public abstract void Dispose();

    }




}
