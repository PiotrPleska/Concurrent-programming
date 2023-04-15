using Data;

namespace Logic
{

    internal class Logic : LogicAbstractApi
    {
        private LogicBall LogicBall;
        private DataAbstractApi dataLayer;

        private List<ILogicBall> Table = new List<ILogicBall>();
        internal Logic(DataAbstractApi dataLayer = null)
        {

            this.dataLayer = DataAbstractApi.CreateApi();

        }


        public override void Dispose()
        {
            dataLayer?.Dispose();
        }

        public override ILogicBall getBall()
        {
            return LogicBall;
        }

        public override List<ILogicBall> GetBalls()
        {
            return Table;
        }

        

        public override void Start(int ballCount)
        {
            if (Table != null) Table.Clear();
            for (int i = 0; i < ballCount; i++)
            {
                LogicBall ball = new LogicBall(dataLayer.generateBall());
                Table.Add(ball);
            }
        }
    }
}
