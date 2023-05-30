using Logic;
using System.Collections.ObjectModel;

namespace Model
{
    internal class Model : ModelAbstractApi
    {
        private LogicAbstractApi logicLayer;
        private ObservableCollection<IModelBall> ModelBalls = new ObservableCollection<IModelBall>();


        public Model(LogicAbstractApi logicAbstractAPI = null)
        {
            if (logicAbstractAPI != null) { logicLayer = logicAbstractAPI; }
            else { logicLayer = LogicAbstractApi.CreateApi(); }
        }


        public ObservableCollection<IModelBall> SGModelBalls
        {
            get { return ModelBalls; }
            set { ModelBalls = value; }
        }

        public override ObservableCollection<IModelBall> GetModelBalls()
        {
            List<ILogicBall> logicBalls = logicLayer.GetBalls();
            if (SGModelBalls != null)
            {
                SGModelBalls.Clear();
            }

            foreach (ILogicBall logicBall in logicBalls)
            {
                SGModelBalls.Add(new ModelBall(logicBall));
            }

            return SGModelBalls;
        }


        public override void Dispose()
        {
            logicLayer.Dispose();
        }

        public override void Start(int ballCount)
        {
            logicLayer.Start(ballCount);
        }
    }
}