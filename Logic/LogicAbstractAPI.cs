using Data;

namespace Logic
{
    public abstract class LogicAbstractApi : IDisposable
    {
        public static LogicAbstractApi CreateApi(DataAbstractApi abstractDataApi = null)
        {
            return new Logic(abstractDataApi);
        }

        public abstract List<BallsLogic> GetBalls();

        public abstract void Start(int ballCount);
        public abstract void Dispose();

    }
}