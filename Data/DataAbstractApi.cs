using System.ComponentModel;

namespace Data
{

  

    public abstract class DataAbstractApi : IDisposable
    {
        public static DataAbstractApi CreateApi()
        {
            Data model = new Data();
            return model;
        }

        public abstract Ball GenerateBall();

        public abstract void Dispose();
        public abstract void Start();

        public abstract List<Ball> GetAll();

    }


}
