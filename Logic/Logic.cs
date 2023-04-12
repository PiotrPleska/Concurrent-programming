using Data;

namespace Logic
{

    public class BallChangeEventArgs : EventArgs
    {
        public ILogicBall Ball { get; internal set; }
    }

    internal class Logic : LogicAbstractApi
    {
        private DataAbstractApi dataLayer;

        private List<ILogicBall> Table = new List<ILogicBall>();
        internal Logic(DataAbstractApi dataLayer = null)
        {

            this.dataLayer = DataAbstractApi.CreateApi();

        }

        public event EventHandler<BallChangeEventArgs> BallChange;


        public override void Dispose()
        {
            dataLayer?.Dispose();
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
                BallChange?.Invoke(this,new BallChangeEventArgs(){Ball=ball});
            }
        }
    }
}
