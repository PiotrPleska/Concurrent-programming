using Logic;
using System.Collections.ObjectModel;

namespace Model
{
    internal class Model : ModelAbstractApi
    {
        private LogicAbstractApi logicLayer;
        private ObservableCollection<ModelBall> ModelBalls = new ObservableCollection<ModelBall>();


        public Model(LogicAbstractApi logicAbstractAPI = null)
        {
            this.logicLayer = LogicAbstractApi.CreateApi();
        }


        public ObservableCollection<ModelBall> SGModelBalls
        {
            get { return ModelBalls; }
            set { ModelBalls = value; }
        }

        public override ObservableCollection<ModelBall> GetModelBalls()
        {
            List<BallsLogic> logicBalls = logicLayer.GetBalls();
            if (SGModelBalls != null)
            {
                SGModelBalls.Clear();
            }

            foreach (BallsLogic logicBall in logicBalls)
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