using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Data;
using Microsoft.VisualBasic;

namespace Logic
{
    public class BallsLogic: INotifyPropertyChanged

    {
        private Ball ball;

        public event PropertyChangedEventHandler? PropertyChanged;

        public double Y
        {
            get { return ball.Y; }
            private set
            {
                if (ball.Y == value)
                    return;
                ball.Y = value;
                RaisePropertyChanged("Y");
            }
        }

        public double X
        {
            get { return ball.X; }
            private set
            {
                if (ball.X == value)
                    return;
                    ball.X = value;
                RaisePropertyChanged("X");
            }
        }

        public double Diameter {
            get
            {
                return ball.diameter;
            }
            internal set
            {
                //if (ball.Diameter == value)
                //    return;
                //ball.Diameter = value;
                //RaisePropertyChanged("Diameter");
            }
            }

        public BallsLogic(Ball ball)
        {
            this.ball = ball;
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public void borderColision(Ball ball) {


        //        if ((ball.x + ball.diameter) >= 400)
        //        {

        //            orb.X = DataApi.Scene.Width - orb.Radius;
        //        }
        //        if ((orb.X - orb.Radius) <= 0)
        //        {
        //            orb.XSpeed = -orb.XSpeed;
        //            orb.X = orb.Radius;
        //        }
        //        if ((orb.Y + orb.Radius) >= DataApi.Scene.Height)
        //        {
        //            orb.YSpeed = -orb.YSpeed;
        //            orb.Y = DataApi.Scene.Height - orb.Radius;
        //        }
        //        if ((orb.Y - orb.Radius) <= 0)
        //        {
        //            orb.YSpeed = -orb.YSpeed;
        //            orb.Y = orb.Radius;
        //        }

        //}


    }
}
