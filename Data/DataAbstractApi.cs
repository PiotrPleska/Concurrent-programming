using System.ComponentModel;

namespace Data
{
    public interface IBall : INotifyPropertyChanged
    {
        double Y { get; }
        double X { get; }
        double Diameter { get; }
    }

    public class BallChaneEventArgs : EventArgs
    {
        public IBall Ball { get; internal set; }
    }

    public abstract class DataAbstractApi : IObservable<IBall>, IDisposable
    {
        public static DataAbstractApi CreateApi()
        {
            Data model = new Data();
            return model;
        }

        public abstract void Start();


        public abstract IDisposable Subscribe(IObserver<IBall> observer);



        public abstract void Dispose();

    }


}
