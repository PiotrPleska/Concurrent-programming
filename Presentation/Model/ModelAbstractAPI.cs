using Data;
using Logic;
using System.Collections.ObjectModel;

namespace Model
{
    public abstract class ModelAbstractAPI
    {
        public static ModelAbstractAPI CreateApi(LogicAbstractAPI abstractLogicApi = null)
        {
            return new Model(abstractLogicApi);
        }

        public abstract ObservableCollection<ModelBall> GetModelBalls();

        public abstract void Start();
        public abstract void Dispose();
    }
}