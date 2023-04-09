using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class Logic:LogicAbstractAPI
    {
        private DataAbstractApi dataLayer;
        private List<BallsLogic> Table = new List<BallsLogic>();
        internal Logic(DataAbstractApi dataLayer = null)
        {
      
                this.dataLayer = DataAbstractApi.CreateApi();
            
        }

        public override void Dispose()
        {
            dataLayer.Dispose();
        }

        public override List<BallsLogic> GetBalls()
        {
            if (Table != null)
            {
                Table.Clear();
            }
            foreach (Ball ball in dataLayer.GetAll())
            {
                this.Table.Add(new BallsLogic(ball));
            }
            return Table;
        }

        public override void Start()
        {

            dataLayer.Start();

        }
    }
}
