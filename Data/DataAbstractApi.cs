using System.ComponentModel;

namespace Data
{



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

    public interface IBall: INotifyPropertyChanged
    {
        double X { get; set; }
        double Y { get; set; }
        double Diamiter { get; set; }
    }


}
