using Data;
using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class Model : ModelAbstractAPI
    {

        private LogicAbstractAPI logicLayer;
        private ObservableCollection<ModelBall> ModelBalls = new ObservableCollection<ModelBall>();


        public Model(LogicAbstractAPI logicAbstractAPI = null) 
        {
        
                this.logicLayer = LogicAbstractAPI.CreateApi();
          
        }



        public ObservableCollection<ModelBall> SGModelBalls
        {
            get
            {
                return ModelBalls;
            }
            set
            {
                ModelBalls = value;
            }
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

        public override void Start()
        {
            logicLayer.Start();
        }
    }
}
