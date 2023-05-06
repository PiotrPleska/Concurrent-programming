using Logic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    internal class ModelBall : IModelBall, INotifyPropertyChanged
    {
        private static LogicAbstractApi API = LogicAbstractApi.CreateApi();
        private double x;
        private double y;
        private double diameter;

        public ModelBall(ILogicBall ball)
        {
            this.x = ball.X;
            this.y = ball.Y;
            this.Diamiter = ball.Diamiter;
            ball.PropertyChanged += UpdateCoordinates;
        }


        public double X
        {
            get { return this.x; }
            set
            {
                this.x = value;
            }
        }

        public double Y
        {
            get => this.y;

                set
                {
                    this.y = value;
                }
}

        public double Diamiter
        {
            get { return this.diameter; }
            set => this.diameter = value;
        }

        public double speed => throw new NotImplementedException();

        private void UpdateCoordinates(object sender, EventArgs e)
        {
            ILogicBall ballsLogic = (ILogicBall)sender;
            x = ballsLogic.X;
            y = ballsLogic.Y;
            RaisePropertyChanged("X");
            RaisePropertyChanged("Y");
        }


        public event PropertyChangedEventHandler? PropertyChanged;


        protected void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}