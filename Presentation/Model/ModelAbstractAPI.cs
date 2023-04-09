using Data;
using Logic;
using System.Collections.ObjectModel;

namespace Model
{
    public abstract class ModelAbstractAPI :IDisposable
    {
        public static ModelAbstractAPI CreateApi(LogicAbstractAPI logicLayer = null)
        {
            return new Model(logicLayer);
        }

        public abstract ObservableCollection<ModelBall> GetModelBalls();

        public abstract void Start();
        public abstract void Dispose();
    }
}