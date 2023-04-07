using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data
{
 public class Ball : IBall, IDisposable
  {
    public Ball(double Y, double X)
    {
      YBackingField = Y;
      XBackingField = X;
      MoveTimer = new Timer(Move, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(100));
    }


    public double Y
    {
      get { return YBackingField; }
      set// zmienic na prywatne
            {
        if (YBackingField == value)
          return;
        YBackingField = value;
        RaisePropertyChanged();
      }
    }

    public double X
    {
      get { return XBackingField; }
       set // zmienic na prywatne 
      {
        if (XBackingField == value)
          return;
        XBackingField = value;
        RaisePropertyChanged();
      }
    }

    public double Diameter { get; internal set; }


    public event PropertyChangedEventHandler PropertyChanged;




    public void Dispose()
    {
      MoveTimer.Dispose();
    }



    private double YBackingField;
    private double XBackingField;
    private Timer MoveTimer;
    private Random Random = new Random();

    private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void Move(object state)
    {
      if (state != null)
        throw new ArgumentOutOfRangeException(nameof(state));
      Y = Y + (Random.NextDouble() - 0.5) * 10;
      X = X + (Random.NextDouble() - 0.5) * 10;
    }

  }
}

