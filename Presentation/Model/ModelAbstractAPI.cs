using Logic;
using System.Collections.ObjectModel;

namespace Model
{
    public interface IModelBall
    {
        public double X { get; }
        public double Y { get; }
        public double Diamiter { get; }
        
    }

    public abstract class ModelAbstractApi : IDisposable
    {
        public static ModelAbstractApi CreateApi(LogicAbstractApi logicLayer = null)
        {
            return new Model(logicLayer);
        }

        public abstract ObservableCollection<IModelBall> GetModelBalls();

        public abstract void Start(int ballCount);
        public abstract void Dispose();
    }
}