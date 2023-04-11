using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data
{
    public class Ball : IDisposable, INotifyPropertyChanged
    {
        private readonly double Diameter;
        private Timer MoveTimer;
        private Random Random = new Random();
        private double YBackingField;
        private double XBackingField;
        public Ball(double Y, double X)
        {
            XBackingField = X;
            YBackingField = Y;
            this.Diameter = 20;
            MoveTimer = new Timer(Move, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(100));
        }


        public double Y
        {
            get { return YBackingField; }
            set
            {
                if (YBackingField == value)
                    return;
                YBackingField = value;
                RaisePropertyChanged("Y");
            }
        }


        public double X
        {
            get { return XBackingField; }
            set
            {
                if (XBackingField == value)
                    return;
                XBackingField = value;
                RaisePropertyChanged("X");
            }
        }
        public double diameter { get { return Diameter; } }

        public void Dispose()
        {
            MoveTimer.Dispose();
        }
        private void Move(object state)
        {
            if (state != null)
                throw new ArgumentOutOfRangeException(nameof(state));
            Y = Y + (Random.NextDouble() - 0.5) * 10;
            X = X + (Random.NextDouble() - 0.5) * 10;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

