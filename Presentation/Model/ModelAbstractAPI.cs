using Data;
using Logic;
using System.Collections.ObjectModel;

namespace Model
{
    public interface IModelBall
    {
        public Vector2D Coordinates { get; }
        public double X { get; }
        public double Y { get; }
        public double Diamiter { get; }
        
    }

    public abstract class ModelAbstractApi : IDisposable
    {
        public static ModelAbstractApi CreateApi(LogicAbstractApi? logicLayer)
        {
            return new Model(logicLayer);
        }
        public static ModelAbstractApi CreateApi()
        {
            return new Model();
        }
        public abstract ObservableCollection<IModelBall> GetModelBalls();

        public abstract void Start(int ballCount);
        public abstract void Dispose();
    }
}