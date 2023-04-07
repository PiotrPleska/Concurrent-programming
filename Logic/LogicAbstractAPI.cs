using Data;

namespace Logic
{
    public abstract class LogicAbstractAPI
    {
        public static LogicAbstractAPI CreateApi(DataAbstractApi abstractDataApi = null)
        {
            return new Logic(abstractDataApi);
        }

        public abstract List<BallsLogic> GetBalls();

        public abstract void Start();
        public abstract void Dispose();

    }
}