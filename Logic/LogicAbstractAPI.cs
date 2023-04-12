using Data;
using System.ComponentModel;

namespace Logic
{
    public interface ILogicBall : INotifyPropertyChanged
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Diamiter { get; }
    }
    public abstract class LogicAbstractApi : IDisposable
    {
        public static LogicAbstractApi CreateApi(DataAbstractApi abstractDataApi = null)
        {
            return new Logic(abstractDataApi);
        }

        public abstract ILogicBall getBall();

        public abstract List<ILogicBall> GetBalls();

        public abstract void Start(int ballCount);
        public abstract void Dispose();

    }
}