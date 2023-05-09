using Data;

namespace Logic
{

    internal class Logic : LogicAbstractApi
    {
        private LogicBall LogicBall;
        internal static DataAbstractApi dataLayerr;

        private List<ILogicBall> Table = new List<ILogicBall>();
        internal Logic(DataAbstractApi dataLayer = null)
        {

            if (dataLayer != null) { dataLayerr = dataLayer; }
            else { dataLayerr = DataAbstractApi.CreateApi(); }

        }


        public override void Dispose()
        {
            dataLayerr?.Dispose();
        }

        public override ILogicBall getBall()
        {
            return LogicBall;
        }

        public override  List<ILogicBall> GetBalls()
        {
            if(Table != null) Table.Clear();
            foreach (IBall b in dataLayerr.getBalls())
            {
                Table.Add(new LogicBall(b));
            }
            return Table;
        }

        public override void Start(int ballCount)
        {
            dataLayerr.Start(ballCount);
        }
    }
}
