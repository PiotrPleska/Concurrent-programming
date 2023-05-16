using Data;
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
        private Vector2D position;
        private double diameter;

        public ModelBall(ILogicBall ball)
        {
            position = ball.Coordinates;
            this.Diamiter = ball.Diamiter;
            ball.CoordinatesChanged += UpdateCoordinates;
        }



        public double Diamiter
        {
            get { return this.diameter; }
            set => this.diameter = value;
        }

        public Vector2D Coordinates => position;

        public double X => x;

        public double Y => y;

        private void UpdateCoordinates(object sender, EventArgs e)
        {
            ILogicBall ballsLogic = (ILogicBall)sender;
            position = ballsLogic.Coordinates;
            x = position.GetX();
            y = position.GetY();
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