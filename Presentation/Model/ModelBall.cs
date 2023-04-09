using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Logic;
using Microsoft.VisualBasic;

namespace Model
{
    public class ModelBall : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double diameter;

        public ModelBall(BallsLogic ball)
        {
            this.x = ball.X;
            this.y = ball.Y;
            this.diameter = ball.Diameter;
        }

      

        public double Y
        {
            get { return y; }
            private set
            {
                if (y == value)
                    return;
                RaisePropertyChanged("Y");
            }
        }

        public double X
        {
            get { return x; }
            private set
            {
                if (x == value)
                    return;
                RaisePropertyChanged("X");
            }
        }

        public double Diameter 
        {
            get { return diameter; }
            private set
            {
                //if (x == value)
                //    return;
                //RaisePropertyChanged("X");
            }
        }





        public event PropertyChangedEventHandler? PropertyChanged;


        protected void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
