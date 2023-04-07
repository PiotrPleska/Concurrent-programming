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

        private LogicAbstractAPI LogicAbstractAPI = LogicAbstractAPI.CreateApi(null);

        private ObservableCollection<ModelBall> ModelBalls = new ObservableCollection<ModelBall>();


        public Model(LogicAbstractAPI logicAbstractAPI = null) 
        {
            if (logicAbstractAPI == null)
            {
                this.LogicAbstractAPI = LogicAbstractAPI.CreateApi();
            }
            else
            {
                this.LogicAbstractAPI = logicAbstractAPI;
            }
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


        public override void Dispose()
        {
            LogicAbstractAPI.Dispose();
        }

        public override ObservableCollection<ModelBall> GetModelBalls()
        {
            return this.ModelBalls;
        }

        public override void Start()
        {
            LogicAbstractAPI.Start();
        }
    }
}
