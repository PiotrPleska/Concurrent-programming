using System.Reactive;
using System.Reactive.Linq;

namespace Data
{

    internal class Data : DataAbstractApi
    {
        public Data()
        {
            eventObservable = Observable.FromEventPattern<BallChaneEventArgs>(this, "BallChanged");
        }

        public override void Dispose()
        {
            foreach (Ball item in Balls2Dispose)
                item.Dispose();
        }

        public override IDisposable Subscribe(IObserver<IBall> observer)
        {
            return eventObservable.Subscribe(x => observer.OnNext(x.EventArgs.Ball), ex => observer.OnError(ex), () => observer.OnCompleted());
        }

        public override void Start()
        {
            Random random = new Random();
            int ballNumber = random.Next(1, 10);
            for (int i = 0; i < ballNumber; i++)
            {
                Ball newBall = new Ball(random.Next(100, 400 - 100), random.Next(100, 400 - 100)) { Diameter = 20 };
                Balls2Dispose.Add(newBall);
                BallChanged?.Invoke(this, new BallChaneEventArgs() { Ball = newBall });
            }
        }


        public event EventHandler<BallChaneEventArgs> BallChanged;



        private IObservable<EventPattern<BallChaneEventArgs>> eventObservable = null;
        private List<IDisposable> Balls2Dispose = new List<IDisposable>();

    }




}
