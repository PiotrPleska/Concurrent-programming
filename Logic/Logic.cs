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
        private DataAbstractApi dataApi;
        private List<BallsLogic> table = new List<BallsLogic>();
        internal Logic(DataAbstractApi abstractDataApi = null)
        {
            if (abstractDataApi == null)
            {
                
                this.dataApi = DataAbstractApi.CreateApi();
            }
            else
            {
                this.dataApi = abstractDataApi;
            }
        }

        public override void Dispose()
        {
            dataApi.Dispose();
        }

        public override List<BallsLogic> GetBalls()
        {
            foreach (Ball ball in dataApi.GetAll())
            {
                this.table.Add(new BallsLogic(ball));
            }
            return table;
        }

        public override void Start()
        {
            dataApi.Start();
        }
        private void Update(object sender, PropertyChangedEventArgs ev)
        {
            Ball ball = (Ball)sender;
            if (ev.PropertyName == "Position")
            {
                BorderColision(ball);
            }
        }
        private void BorderColision(Ball ball)
        {
            if ((ball.X + ball.Diameter) >= 400)
            {
                ball.X = 420 - ball.Diameter;
            }
            if ((ball.X - ball.Diameter) <= 0)
            {
                ball.X = ball.Diameter;
            }
            if ((ball.Y + ball.Diameter) >= 420)
            {
                ball.Y = 420 - ball.Diameter;
            }
            if ((ball.Y - ball.Diameter) <= 0)
            {
                ball.Y = ball.Diameter;
            }
        }


    }
}
